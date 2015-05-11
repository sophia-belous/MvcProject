using MyBlog.Models.AccountModels;
using MyBlog.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class BloggingDbContext : DbContext
    {
        public BloggingDbContext()
            : base("DefaultConnection")
        { 
        }

        public DbSet<UserProfile> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}