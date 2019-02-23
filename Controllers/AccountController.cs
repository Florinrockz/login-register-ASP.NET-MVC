using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginRegisterMVC.Models;

namespace LoginRegisterMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (OurDbcontext dc = new OurDbcontext())
            {
                return View(dc.userAccount.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using (OurDbcontext dc = new OurDbcontext())
                {
                    dc.userAccount.Add(account);
                    dc.SaveChanges();
                }

                ModelState.Clear();

                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registered!";
            }

            return View();

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount us)
        {
            using(OurDbcontext dc = new OurDbcontext())
            {
                var user = dc.userAccount.Single(ua => ua.Username == us.Username && ua.Password == us.Password);

                if (user!=null)
                {
                    Session["UserId"] = user.Id.ToString();
                    Session["Username"] = user.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong");
                }
            }

            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}