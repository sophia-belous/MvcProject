using MyBlog.Models;
using MyBlog.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models.AccountModels;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private BloggingDbContext db = new BloggingDbContext();

        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Dispose
    }
}