using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }

    }
}