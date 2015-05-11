using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Models.BlogModels
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}