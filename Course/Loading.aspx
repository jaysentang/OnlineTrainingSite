<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Loading.aspx.cs" Inherits="Course_Loading" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">


  
   

    <style>
/* The Modal (background) */
.modal {
    display: none; /* Hidden by default */
    position: fixed; /* Stay in place */
    z-index: 1; /* Sit on top */
    padding-top: 100px; /* Location of the box */
    left: 0;
    top: 0;
    width: 100%; /* Full width */
    height: 100%; /* Full height */
    overflow: auto; /* Enable scroll if needed */
    background-color: rgb(0,0,0); /* Fallback color */
    background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
}

/* Modal Content */
.modal-content {
    background-color: #fefefe;
    margin: auto;
    padding: 20px;
    border: 1px solid #888;
    width: 50%;
    height:50%;
}

.close {
    color: #aaaaaa;
    float: right;
    font-size: 28px;
    font-weight: bold;
}

.close:hover,
.close:focus {
    color: #000;
    text-decoration: none;
    cursor: pointer;
}

span.close2 {
    color: #aaaaaa;
    float: right;
    font-size: 15px;
    font-weight: bold;
    display:none;
}

span.close3 {
      color: #aaaaaa;
    float: right;
    font-size: 15px;
    font-weight: bold;
    display:block;  
}

span.close3:hover,
span.close3:focus {
    color: #000;
    text-decoration: none;
    cursor: pointer;
}

/*Wall Post*/



.publishContainer
{
   
    text-align: right;
    background-color: #F2F2F2;
    border-color: #B4BBCD;
    border-image: none;
    border-style: solid;
    border-width: 1px;
    padding: 1em 1.2em ;
    margin-bottom:2em;
}

.publishComment
{
    text-align: right;
    width: 100%;
    display: none;
}


    #msgHolder img
    {
        float: left;
        margin-right: 7px;
    }

    #msgHolder a
    {
        
        text-decoration: none;
        color: #015BA7;
    }

        #msgHolder a:hover
        {
            text-decoration: none;
        }

.postHolder
{
    padding: 5px;
    border-bottom: solid 1px #E6E6E6;
    margin: 5px;
   list-style:none;
}

    .postHolder p
    {
        margin: 4px auto 1px 0px;
        word-wrap:break-word;
    }

    .postHolder a
    {
        font-weight: bold;
    }

.postFooter
{
    font-size: 0.85em;
   
}

    .postFooter span
    {
        color: #7D7D84;
    }

    .postFooter a
    {
        font-weight: normal;
    }

.commentHolder
{
    clear: both;
    background-color: #EEF1F6;
    padding: 5px;
    border-bottom: 1px solid #DEE5EA;
    border-top: 1px solid white;
    list-style:none;
}

#btnShare, .btnComment, .btnRequest, .btn
{
  background-color: #5B74A8;
    border: 0 none;
    color: #FFFFFF;
    cursor: pointer;  
    font-size: 13px;
    font-weight: bold;
    margin-top: 2px;
    padding: 5px;
    text-align: center;
    
}

ul{
    -webkit-padding-start: 0px;

}

#popOut {
    right:0;
    left:0;
    height: 100%;
    position: fixed; /* Stay in place */
    z-index: 1;   
    visibility:visible;
    display:none;
    background-color: rgba(22,22,22,0.5);
}

#popOut:target {
    visibility: visible;
    display: block;
}
.reveal-modal {
    background:#e1e1e1; 
    margin: 0 auto;
    text-align:center;
    position:relative; 
    z-index:41;
    top: 25%;
    padding:30px; 
    -webkit-box-shadow:0 0 10px rgba(0,0,0,0.4);
    -moz-box-shadow:0 0 10px rgba(0,0,0,0.4); 
    box-shadow:0 0 10px rgba(0,0,0,0.4);
}


#MainContent_container {
	width: 100%;
	height: auto;
	position: relative;
}

#video-controls {
	position: absolute;
	bottom: 0;
	left: 0;
	right: 0;
	padding: 5px;
	opacity: 0;
	-webkit-transition: opacity .3s;
	-moz-transition: opacity .3s;
	-o-transition: opacity .3s;
	-ms-transition: opacity .3s;
	transition: opacity .3s;
	background-image: linear-gradient(bottom, rgb(3,113,168) 13%, rgb(0,136,204) 100%);
	background-image: -o-linear-gradient(bottom, rgb(3,113,168) 13%, rgb(0,136,204) 100%);
	background-image: -moz-linear-gradient(bottom, rgb(3,113,168) 13%, rgb(0,136,204) 100%);
	background-image: -webkit-linear-gradient(bottom, rgb(3,113,168) 13%, rgb(0,136,204) 100%);
	background-image: -ms-linear-gradient(bottom, rgb(3,113,168) 13%, rgb(0,136,204) 100%);

	background-image: -webkit-gradient(
		linear,
		left bottom,
		left top,
		color-stop(0.13, rgb(3,113,168)),
		color-stop(1, rgb(0,136,204))
	);
}

#MainContent_container:hover #video-controls {
	opacity: .9;
}

#video-controls button {
	background: rgba(0,0,0,.5);
	border: 0;
	color: #EEE;
	-webkit-border-radius: 3px;
	-moz-border-radius: 3px;
	-o-border-radius: 3px;
	border-radius: 3px;
}

#video-controls button:hover {
	cursor: pointer;
}

#seek-bar {
	width: 360px;
}

#volume-bar {
	width: 60px;
}
</style>
    <!--customize video player-->
   
    <!--link rel="stylesheet" href="../Content/prettyPhoto.css" type="text/css" media="screen" title="prettyPhoto main stylesheet" />
		<script src="../Scripts/jquery-prettyPhoto.js" type="text/javascript" charset="utf-8"></script-->
     <div id="popOut">
    <div id="exampleModal" class="reveal-modal">
     <h2>Information</h2>
     <p>
    There has a quiz section, are you ready for the quiz?
    </p>
        <div style="text-align:center;">
     <input type="button" value="Yes" class="yes-reveal-modal"/>
     <input type="button" value="Skip" class="skip-reveal-modal"/>
    </div>
        </div>
    </div>
            <div class="panel-heading">
                <div class="panel-title">
                    <h3 runat="server" id="Header" style="color: #111; font-family: 'Open Sans Condensed', sans-serif; font-size: 35px; font-weight: 700;   text-transform: uppercase;"></h3>
                </div>
            </div>    
    <!--div class="row">
             
            <div class="col-md-12"><i class="glyphicon glyphicon-arrow-left"></i><span class="pull-right"><i class="glyphicon glyphicon-arrow-right"></i></span></div>
           
        </div-->


       <div class="col-md-12">
        <div class="content-box-course">
            
            <div runat="server" class="panel-body" id="container">
                <video id="play" oncontextmenu="return false;" class="video" autoplay="autoplay"  style="width: 100%; height: auto;" controls="controls" preload="none">
                    <source runat="server" id="cVideo" />
                    <source runat="server" id="cVideo2" />
                    <p>Your browser does not support the video tag.</p>
                </video>

                 <!--div id="video-controls">
                    <button type="button" id="play-pause">Pause</button>
                    <input type="range" id="seek-bar" value="0">
                    <button type="button" id="mute">Mute</button>
                    <input type="range" id="volume-bar" min="0" max="1" step="0.1" value="1">
                    <button type="button" id="full-screen" style="float:right;">Full-Screen</button>
                 </!div-->

                <!--http://blog.teamtreehouse.com/building-custom-controls-for-html5-videos
                    https://css-tricks.com/custom-controls-in-html5-video-full-screen/
                    -->
            </div>
            </div>
           </div>
     
   
    <!--

     <div class="col-md-8">
            <div data-bind="visible: notifications().length > 0, foreach: notifications">
                <div class="summary alert alert-success alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                    <p data-bind="text: $data"></p>
                </div>
            </div>
 
            <div class="new-post pad-bottom" data-bind="visible: signedIn">
                <form data-bind="submit: writePost">
                    <div class="form-group">
                        <label for="message">Write a new post:</label>
                        <textarea class="form-control" name="message" id="message" placeholder="New post"></textarea>
                    </div>
                    <button type="submit" class="btn btn-default">Submit</button>
                </form>
            </div>
 
            <ul class="posts list-unstyled" data-bind="foreach: posts">
                <li>
                    <p>
                        <span data-bind="text: username" class="username"></span><br />
                    </p>
                    <p>
                        <span data-bind="text: message"></span>
                    </p>
 
                    <p class="no-pad-bottom date-posted">Posted <span data-bind="text: moment(date).calendar()" /></p>
 
                    <div class="comments" data-bind="visible: $parent.signedIn() || comments().length > 0">
                        <ul class="list-unstyled" data-bind="foreach: comments, visible: comments().length > 0">
                            <li>
 
                                <p>
                                    <span class="commentor" data-bind="text: username"></span>
                                    <span data-bind="text: message"></span>
                                </p>
                                <p class=" no-pad-bottom date-posted">Posted <span data-bind="text: moment(date).calendar()" /></p>
                            </li>
                        </ul>
 
                        <form class="add-comment" data-bind="visible: $parent.signedIn, submit: addComment">
                            <div class="row">
                                <div class="col-md-9">
                                    <input type="text" class="form-control" name="comment" placeholder="Add a comment" />
                                </div>
                                <div class="col-md-3">
                                    <button class="btn btn-default" type="submit">Add Comment</button>
                                </div>
                            </div>
                        </form>
                    </div>
                </li>
            </ul>
        </div>
   
   -->
 <div class="publishContainer">
    <textarea class="msgTextArea" id="txtMessage" data-bind="textInput: newMessage, jqAutoresize: {}" style="height:3em;" placeholder="Any Question?"></textarea>
    <input type="button" data-url="/Wall/SavePost" value="Post" id="btnShare" data-bind="click: addPost">
</div>
<p class="error" style="color:red" data-bind="text:error"></p>
<div class="notification" data-bind="visible: newPosts().length > 0"><a data-bind="click: loadNewPosts"> <span data-bind="    text: newPosts().length"></span> new post(s)</a></div>
<ul id="msgHolder" data-bind="foreach: posts">
    <li class="postHolder">
        <!--img data-bind="attr: { src: PostedByAvatar }"--><p><a data-bind="text: PostedByName"></a>: <span data-bind="    html: Message"></span></p>
        <div class="postFooter">
            <span class="timeago" data-bind="text: PostedDate"></span>&nbsp;<!--a class="linkComment" href="#" data-bind="    click: toggleComment">Comment</a-->&nbsp;
            <a class="commentNotification" data-bind="click: loadNewComments, visible: NewComments().length > 0"> <span data-bind="    text: NewComments().length"></span> new comment(s)</a> 
            <div class="commentSection">
                <ul data-bind="foreach: PostComments">
                    <li class="commentHolder" data-bind="attr: { value: CommentedBy }/*, event: { mouseover: enableDelete(CommentedBy, status $('.commentHolder').find('.close2')}*/">
                        <!--img  data-bind="attr: { src: CommentedByAvatar }"--><p><span class="close2" >x</span><a data-bind="    text: CommentedByName "></a>: <span data-bind="    html: Message"></span></p>
                        <div class="commentFooter"> <span class="timeago" data-bind="text: CommentedDate"></span>&nbsp;</div>
                    </li>
                </ul>
                <div style="display: block" class="publishComment">
                    <textarea class="commentTextArea" data-bind="textInput: newCommentMessage, jqAutoresize: {}" placeholder="write a comment..."></textarea>
                    <input type="button"  value="Comment" class="btnComment" data-bind="click: addComment"/>
                </div>
            </div>
        </div>
    </li>
</ul>

 

 <div id="myModal" class="modal">

  <!-- Modal content -->
  <div class="modal-content" style="text-align:center; display:table;">
    <span class="close">×</span>
    <p id="testing" style="display:table-row; vertical-align:middle;"></p>
  </div>

        
</div>
    <asp:HiddenField runat="server" ID="user" ClientIDMode="Static" />
   
    <!--div class="container">
    <input type="text" id="message" />
    <input type="button" id="sendmessage" value="Send" />
    <input type="hidden" id="displayname" />
    <ul id="discussion"></ul>
</!--div-->

    <script type="text/javascript">
        

        var timer;
        //video player button
        var video = document.getElementById("play");
    
        // Buttons
       // var playButton = document.getElementById("play-pause");
        //var muteButton = document.getElementById("mute");
        //var fullScreenButton = document.getElementById("full-screen");

        // Sliders
//        var seekBar = document.getElementById("seek-bar");
  //      var volumeBar = document.getElementById("volume-bar");


        var modal = document.getElementById('myModal');

        // Get the <span> element that closes the modal
        var span = document.getElementsByClassName("close")[0];

        // When the user clicks the button, open the modal
      
       
       
        span.onclick = function () {
            modal.style.display = "none";
            document.getElementById("testing").innerText = "";
            clearInterval(timer);
 
        }

        video.addEventListener("click", function () {
            if (video.paused == true) {
                video.play();
            //    playButton.innerHTML = "Pause";

            } else {

                video.pause();
              //  playButton.innerHTML = "Play";
            }
        });

        /*
        playButton.addEventListener("click", function () {
            if (video.paused == true) {
                // Play the video
                video.play();

                // Update the button text to 'Pause'
                playButton.innerHTML = "Pause";
            } else {
                // Pause the video
                video.pause();

                // Update the button text to 'Play'
                playButton.innerHTML = "Play";
            }
        });

        
        muteButton.addEventListener("click", function () {
            if (video.muted == false) {
                // Mute the video
                video.muted = true;

                // Update the button text
                muteButton.innerHTML = "Unmute";
            } else {
                // Unmute the video
                video.muted = false;

                // Update the button text
                muteButton.innerHTML = "Mute";
            }
        });


        fullScreenButton.addEventListener("click", function () {
            if (video.requestFullscreen) {
                video.requestFullscreen();
            } else if (video.mozRequestFullScreen) {
                video.mozRequestFullScreen(); // Firefox
            } else if (video.webkitRequestFullscreen) {
                video.webkitRequestFullscreen(); // Chrome and Safari
            }
        });

        video.addEventListener("timeupdate", function () {
            // Calculate the slider value
            var value = (100 / video.duration) * video.currentTime;

            // Update the slider value
            seekBar.value = value;
        });

        seekBar.addEventListener("change", function () {
            // Calculate the new time
            var time = video.duration * (seekBar.value / 100);

            // Update the video time
            video.currentTime = time;
        });

        volumeBar.addEventListener("change", function () {
            // Update the video volume
            video.volume = volumeBar.value;
        });
       */
        video.addEventListener("ended", function () {
            //PageMethods.set_path('WebService.asmx');
            // PageMethods.UpdateSeen(OnSuccess,OnError);
            
            // function OnSuccess(error) {
            //    alert("hi");
            // }
            //function OnError(error) {
            //    alert("bye");
            //}
            //  CallToServer();
          

            var query = getUrlParam()["courseid"]
            var query2 = getUrlParam()["sectionid"]
            var query3 = getUrlParam()["projectid"]

            $.ajax({
                type: "POST",
                url: "Handler.ashx?method=getupdate&sectionid=" + query2 + "&courseid=" + query + "&projectid=" + query3,
                dataType: "text",
                success: ReturnData2,
                error: function (Response, status, error) {
                    var r = jQuery.parseJSON(Response.responseText);
                    alert("Message: " + r.Message);
                    alert("StackTrace: " + r.StackTrace);
                    alert("ExceptionType: " + r.ExceptionType);
                }
            });
        });
        
        function getUrlParam() {
            var parameter = {};
            var url = window.location.href;
            window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi,
             function (m, key, value) {
                 parameter[key] = value;
             });
            return parameter;
        }

        function ReturnData2(data) {
            if (typeof data !='undefined' && data) {
                var param = data.split(",");
                if (param[2] == 'True') {
                    
                    $('div#popOut').show();
                    $('.yes-reveal-modal').click(function () {
                        $('div#popOut').hide();
                        var query = getUrlParam()["courseid"];
                        var location = window.location.href;
                        window.location.href = location.substring(0, location.lastIndexOf("/") + 1) + "Quiz.aspx?examid=" + param[3] + "&courseid=" + query + "&projectid=" + query3;
                    });

                    $('.skip-reveal-modal').click(function () {
                        $('div#popOut').hide();
                        timedRefresh(5, param);
                        modal.style.display = "block";
                    });
                }
                else {
                timedRefresh(5, param);
                modal.style.display = "block";
                }
            }
        }

        function replaceQueryParam(param, newval, search) {
            var regex = new RegExp("([?;&])" + param + "[^&;]*[;&]?");
            var query = search.replace(regex, "$1").replace(/&$/, '');

            return (query.length > 2 ? query + "&" : "?") + (newval ? param + "=" + newval : '');
        }
        
        function timedRefresh(timeoutPeriod, param) {
             timer = setInterval(function () {
                if (timeoutPeriod > 0) {
                    timeoutPeriod -= 1;
                    document.getElementById("testing").innerText = "Next course will be started in " + timeoutPeriod;
                } else {
                    clearInterval(timer);
                    var str = window.location.search
                    str = replaceQueryParam('sectionid', param[0], str)
                    str = replaceQueryParam('courseid', param[1], str)
                    window.location.href = window.location.pathname + str;
                };
            }, 1000);
        };
        

    </script>

    


    <script src="../Scripts/jquery.signalR-2.2.1.js" type="text/javascript"></script>   
    <!--Reference the autogenerated SignalR hub script. -->
    <script src="../signalr/hubs" type="text/javascript"></script>
    <script src="../Scripts/jquery.autosize-min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.timeago.js" type="text/javascript"></script>
    <script src="../Scripts/knockout-3.4.0.js" type="text/javascript"></script>
    <script src="../Scripts/wallpost.js" type="text/javascript"></script>
    
   
    
     <!--script>
        $(function () {
            // Reference the auto-generated proxy for the hub.
            var chat = $.connection.chatHub;
            // Create a function that the hub can call back to display messages.
            chat.client.addNewMessageToPage = function (name, message) {
                // Add the message to the page.
                $('#discussion').append('<li><strong>' + htmlEncode(name)
                    + '</strong>: ' + htmlEncode(message) + '</li>');
            };
            // Get the user name and store it to prepend to messages.
            $('#displayname').val(prompt('Enter your name:', ''));
            // Set initial focus to message input box.
            $('#message').focus();
            // Start the connection.
            $.connection.hub.start().done(function () {
                $('#sendmessage').click(function () {
                    // Call the Send method on the hub.
                    chat.server.send($('#displayname').val(), $('#message').val());
                    // Clear text box and reset focus for next comment.
                    $('#message').val('').focus();
                });
            });
        });
        // This optional function html-encodes messages for display in the page.
        function htmlEncode(value) {
            var encodedValue = $('<div />').text(value).html();
            return encodedValue;
        }
    </!--script-->
</asp:Content>

