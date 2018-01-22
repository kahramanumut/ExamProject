using ExamProject.BusinessLayer;
using ExamProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ExamProject.WebApp.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            
            return RedirectToAction("Index","Home");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User user)
        {
            LoginManager login = new LoginManager();

            if (ModelState.IsValid)
            {
                if (login.LoginCheck(user))
                {
                    FormsAuthentication.SetAuthCookie(user.Username, true);
                    Session["userName"] = user.Username;
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "EMail veya şifre hatalı!");
                }
            }
            return View(user);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}