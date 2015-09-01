using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models.SupportModel;

namespace Shop.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        // GET: AdminHome
        public ActionResult Index()
        {
            ViewBag.Account = Session[SessionKey.LogIn];
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Remove(SessionKey.LogIn);
            return RedirectToAction("LogIn", "AdminLogIn");
        }
    }
}