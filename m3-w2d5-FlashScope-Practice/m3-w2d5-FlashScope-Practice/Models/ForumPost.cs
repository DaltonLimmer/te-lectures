using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace m3_w2d5_FlashScope_Practice.Models
{
    public class ForumPost
    {
        public DateTime PostDate { get; } = DateTime.Now;
        public string PostText { get; set; }

        public ForumPost(string postText)
        {
            PostText = postText;
        }


    }
}