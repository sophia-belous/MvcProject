using MyBlog.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlog.Models.AccountModels
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }

        public virtual List<Like> Likes { get; set; }
        public virtual List<Post> Posts { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}