using MyBlog.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlog.Models.BlogModels
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserProfile User { get; set; }
        public virtual Post Post { get; set; }
    }
}