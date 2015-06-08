using MyBlog.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlog.Models.BlogModels
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
        public string ImgUrl { get; set; }
        public string VideoUrl { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserProfile User { get; set; }

        public virtual List<Comment> Comments { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual List<Like> Likes { get; set; }
    }
}