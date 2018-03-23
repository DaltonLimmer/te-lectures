using m3_w2d5_FlashScope_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace m3_w2d5_FlashScope_Practice.Controllers
{
    public class StringModel
    {
        public string value { get; set; }
    }

    public class HomeController : BaseController
    {
        private static IList<ForumPost> _posts = new List<ForumPost>();

        public ActionResult Index()
        {
            return View(_posts);
        }


        [HttpPost]
        public ActionResult AddPost(string postContent)
        {
            //Add postContent to the database
            _posts.Add(new ForumPost(postContent));

            //Check that it was successfully added
            bool successful = true;

            //If successful:

            if (successful)
            {
                SetMessage("Your post was successfully added", MessageType.Success);
            }
            else
            {
                SetMessage("There was an error adding your post!", MessageType.Error);
            }

            return RedirectToAction("Index");
        }


        public ActionResult ReviewPost()
        {
            ForumPost post = (ForumPost)TempData["postToReview"];

            return View("ReviewPost", post);
        }

        [HttpPost]
        public ActionResult ReviewPost(string postContent)
        {
            ForumPost newPost = new ForumPost(postContent);

            TempData["postToReview"] = newPost;

            //return RedirectToAction("Index");
            return RedirectToAction("ReviewPost");
        }



    }
}