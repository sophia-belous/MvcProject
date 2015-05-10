using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace MyBlog.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login loginData, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                if (WebSecurity.Login(loginData.UserName, loginData.Password))
                {
                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);                  
                    }
                    return RedirectToAction("Index", "Home");                    
                }
                else
                {
                    ModelState.AddModelError("", "Sorry, the username or password is invalid");
                    return View(loginData);
                }
            }

            ModelState.AddModelError("", "Sorry, the username or password is invalid");
            return View(loginData);
            
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register registerData, string role)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(registerData.UserName, registerData.Password);
                    Roles.AddUserToRole(registerData.UserName, role);
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException exception)
                {

                    ModelState.AddModelError("", "Sorry, the username is already exists");
                    return View(registerData);
                }
            }
            ModelState.AddModelError("", "Sorry, the username is already exists");
            return View(registerData);
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}