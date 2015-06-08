using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models;
using MyBlog.Models.BlogModels;

namespace MyBlog.Controllers
{
    public class CommentsController : Controller
    {
        private BloggingDbContext db = new BloggingDbContext();

        [ChildActionOnly]
        public ActionResult Create(int? postId)
        {
            return View(new Comment() { PostId = (int)postId });
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ChildActionOnly]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId, Body")] Comment comment)
        {
            comment.Date = DateTime.Now;
            comment.User = db.Users.First(x => x.Username == User.Identity.Name);
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return View(new Comment() { PostId = comment.PostId });
            }
            return View(comment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
