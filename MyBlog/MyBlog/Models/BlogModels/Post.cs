using MyBlog.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Models.BlogModels
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string Body { get; set; }
        public UserProfile User { get; set; }

        public virtual List<Comment> Comments { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }
}