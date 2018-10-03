/*  It's user control for wall operations like to add/display status and comments. 
*   Developed By: Brij Mohan
*   Website: http://techbrij.com
*   Developed On: 29 May 2013
*  
*/



function getTimeAgo(varDate) {
    if (varDate) {
        return $.timeago(varDate.toString().slice(-1) == 'Z' ? varDate : varDate + 'Z');
    }
    else {
        return '';
    }
}


// Model
function Post(data, hub) {
    var self = this;
    data = data || {};
    self.PostId = data.PostId;
    self.Message = ko.observable(data.Message || "");
    self.PostedBy = data.PostedBy || "";
    self.PostedByName = data.PostedByName || "";
    self.Course = data.Course;
    //self.PostedByAvatar = data.PostedByAvatar || "";
    self.PostedDate = getTimeAgo(data.PostedDate);
    self.error = ko.observable();
    self.PostComments = ko.observableArray();
    self.NewComments = ko.observableArray();
    self.newCommentMessage = ko.observable();   
    self.hub = hub;
    self.addComment = function () {
        if(self.newCommentMessage().toString().length > 0){
            self.hub.server.addComment({ "PostId": self.PostId, "Message": self.newCommentMessage() }).done(function (comment) {
                self.PostComments.push(new Comment(comment));
                self.newCommentMessage('');
            }).fail(function (err) {
                self.error(err);
            });        
        }
    }

    self.loadNewComments = function () {      
        self.PostComments(self.PostComments().concat(self.NewComments()));
        self.NewComments([]);
    }
    self.toggleComment = function (item, event) {
        $(event.target).next().find('.publishComment').toggle();
    }   
     

    if (data.PostComments) {
        var mappedPosts = $.map(data.PostComments, function (item) { return new Comment(item); });
        self.PostComments(mappedPosts);
    }
  
}



function Comment(data) {
    var self = this;
    data = data || {};

    // Persisted properties
    self.CommentId = data.CommentId;
    self.PostId = data.PostId;
    self.Message = ko.observable(data.Message || "");
    self.CommentedBy = data.CommentedBy || "";
   // self.CommentedByAvatar = data.CommentedByAvatar || "";
    self.CommentedByName = data.CommentedByName || "";
    self.CommentedDate = getTimeAgo(data.CommentedDate);
    self.error = ko.observable();
    self.status = ko.observable(false);
}


function getUrlParam() {
    var parameter = {};
    var url = window.location.href;
    window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi,
     function (m, key, value) {
         parameter[key] = value;
     });
    return parameter;
}





function viewModel() {
    var self = this;
   // var status = ko.observable(false);
    self.posts = ko.observableArray();
    self.newMessage = ko.observable();
    self.error = ko.observable();
    self.CommentedBy = ko.observable();
    var client = document.getElementById("user");
    var query = getUrlParam()["courseid"]
    //SignalR related
    self.newPosts = ko.observableArray();
    // Reference the proxy for the hub.  
    self.hub = $.connection.postHub;

    /*
    enableDelete = function (value, status) {
        
        if (value == client.value) {

            status(true);
            /*
            item.addClass('close3');
            item.removeClass('close2');
            /*
           $(".commentHolder").mouseover(function () {
                var item = $(this).find(".close2")
                    item.addClass('close3');
                    item.removeClass('close2');
            }).mouseout(function () {
                var item = $(this).find(".close3")
                item.addClass('close2');
                item.removeClass('close3');
            });
            
        }
    }*/
    
    /*
    disableDelete = function (item) {
        item.addClass('close2');
        item.removeClass('close3');
    }

    */
    self.init = function () {
        self.error(null);
        self.hub.server.getPosts(query).fail(function (err) {
            self.error(err);
        });
    }


    self.addPost = function () {
        self.error(null);
        if(self.newMessage().toString().length > 0){
        self.hub.server.addPost({ "Message": self.newMessage(), "Course":query }).fail(function (err) {
            self.error(err);
        });
        }
    }

    self.loadNewPosts = function () {
        self.posts(self.newPosts().concat(self.posts()));
        self.newPosts([]);
    }

    //functions called by the Hub
    self.hub.client.loadPosts = function (data) {
        var mappedPosts = $.map(data, function (item) { return new Post(item, self.hub); });
        self.posts(mappedPosts);
    }

    self.hub.client.addPost = function (post) {
        if(post.Course == query){
            self.posts.splice(0, 0, new Post(post, self.hub));
            self.newMessage('');
        }
    }

    self.hub.client.newPost = function (post) {
        self.newPosts.splice(0, 0, new Post(post, self.hub));
    }

    self.hub.client.error = function (err) {
        self.error(err);
    }

    self.hub.client.newComment = function (comment, postId, courseId) {
        //check in existing posts
        var posts = $.grep(self.posts(), function (item) {
            return item.PostId === postId;
        });
        if (posts.length > 0) {
            if (courseId == query) {
                posts[0].PostComments.push(new Comment(comment));
                posts[0].newCommentMessage('');
                
            }
        }
        else {
            //check in new posts (not displayed yet)
            posts = $.grep(self.newPosts(), function (item) {
                return item.PostId === postId;
            });
            if (posts.length > 0) {
                if (courseId == query) {
                    posts[0].PostComments.push(new Comment(comment));
                    posts[0].newCommentMessage('');
                }
            }
        }
    }
    return self;
};

//custom bindings
//textarea autosize
ko.bindingHandlers.jqAutoresize = {
    init: function (element, valueAccessor, aBA, vm) {
        if (!$(element).hasClass('msgTextArea')) {
            $(element).css('height', '40px');
        }
        $(element).autosize();
    }
};

var vmPost = new viewModel();
ko.applyBindings(vmPost);
//hope this work
$(".commentHolder").on("mouseover", ".close2", function () {
    var item = $(this).find(".close2")
    item.addClass('close3');
    item.removeClass('close2');
}).on("mouseout",".close3", function () {
    var item = $(this).find(".close3")
    item.addClass('close2');
    item.removeClass('close3');
});

$.connection.hub.start().done(function () {
    vmPost.init();
});
