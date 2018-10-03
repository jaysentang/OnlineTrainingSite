using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
//using WallPostByTechBrij.Models;

namespace WallPostByTechBrij.Hubs
{    
    public class PostHub : Hub
    {
        //private string imgFolder = "/Images/profileimages/";
        //private string defaultAvatar = "user.png";

        // GET api/WallPost
        public void GetPosts(string courseid)
        {
            using (daifukuEntities db = new daifukuEntities())
            {
                var ret = (from post in db.posts.ToList()
                           orderby post.PostedDate descending
                           where post.Course == courseid
                           select new
                           {
                               Message = post.Message,
                               PostedBy = post.PostedBy,
                               PostedByName = post.aspnetuser.UserName,
                               //PostedByAvatar = imgFolder + (String.IsNullOrEmpty(post.UserProfile.AvatarExt) ? defaultAvatar : post.PostedBy + "." + post.UserProfile.AvatarExt),
                               PostedDate = post.PostedDate,
                               PostId = post.PostId,
                               PostComments = from comment in post.postcomments.ToList()
                                              orderby comment.CommentedDate
                                              select new
                                              {
                                                  CommentedBy = comment.CommentedBy,
                                                  CommentedByName = comment.aspnetuser.UserName,
                                                  //CommentedByAvatar = imgFolder + (String.IsNullOrEmpty(comment.UserProfile.AvatarExt) ? defaultAvatar : comment.CommentedBy + "." + comment.UserProfile.AvatarExt),
                                                  CommentedDate = comment.CommentedDate,
                                                  CommentId = comment.CommentId,
                                                  Message = comment.Message,
                                                  PostId = comment.PostId

                                              }
                           }).ToArray();
                Clients.Client(Context.ConnectionId).loadPosts(ret);
            }
        }

        public void AddPost(post post)
        {
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            post.PostedBy = authenticationManager.User.Identity.GetUserId();
            post.PostedDate = DateTime.UtcNow;
            using (daifukuEntities db = new daifukuEntities())
            {
                db.posts.Add(post);
                db.SaveChanges();
                var usr = db.aspnetusers.FirstOrDefault(x => x.Id == post.PostedBy);
                var ret = new
                {
                    Message = post.Message,
                    PostedBy = post.PostedBy,
                    PostedByName = usr.UserName,
                    //PostedByAvatar = imgFolder + (String.IsNullOrEmpty(usr.AvatarExt) ? defaultAvatar : post.PostedBy + "." + post.UserProfile.AvatarExt),
                    PostedDate = post.PostedDate,
                    PostId = post.PostId,
                    Course =post.Course
                };

                Clients.Caller.addPost(ret);
                Clients.Others.addPost(ret);
            }
        }

        public dynamic AddComment(postcomment postcomment)
        {
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            postcomment.CommentedBy = authenticationManager.User.Identity.GetUserId();
            postcomment.CommentedDate = DateTime.UtcNow;
            using (daifukuEntities db = new daifukuEntities())
            {
                db.postcomments.Add(postcomment);
                db.SaveChanges();
                var usr = db.aspnetusers.FirstOrDefault(x => x.Id == postcomment.CommentedBy);
                var course = db.posts.FirstOrDefault(x => x.PostId == postcomment.PostId);
                var ret = new
                {
                    CommentedBy = postcomment.CommentedBy,
                    CommentedByName = usr.UserName,
                    //CommentedByAvatar = imgFolder + (String.IsNullOrEmpty(usr.AvatarExt) ? defaultAvatar : postcomment.CommentedBy + "." + postcomment.UserProfile.AvatarExt),
                    CommentedDate = postcomment.CommentedDate,
                    CommentId = postcomment.CommentId,
                    Message = postcomment.Message,
                    PostId = postcomment.PostId
                };
                Clients.Others.newComment(ret, postcomment.PostId, course.Course);
                return ret;
            }
        }

             
    }
}