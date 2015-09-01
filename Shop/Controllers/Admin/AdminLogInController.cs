using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models.DataModel;
using Shop.Models.SupportModel;
namespace Shop.Controllers.Admin
{
    public class AdminLogInController : Controller
    {
        // GET: AdminLogIn
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(string UserName,string PassWord)
        {
            var error = new AdminModels().LogIn(UserName, PassWord);
            if(error=="")
            {
                Session[SessionKey.LogIn] = UserName;
                return RedirectToAction("Index", "AdminHome");
            }
            else
            {
                ModelState.AddModelError("", error);
            }
            return View();
        }
    }
}