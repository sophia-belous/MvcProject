using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models.BlogModels
{
    public class CommentPostModel
    {
        public Post Post { get; set; }
        public Comment Comment { get; set; }
    }
}