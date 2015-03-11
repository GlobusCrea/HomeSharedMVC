﻿using HomeShareDAL;
using HomeSharedMVC.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeSharedMVC.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string pass)
        {
            Membre m = Membre.getLoginPass(login, pass);
            if (m != null)
            {
                SessionTools.Login = m.Login;
                return RedirectToRoute(new { area = "", controller = "Home", action = "Index" });
            }
            else
            {
                ViewBag.ErrorLogin = "Erreur Login/Password";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            SessionTools.Login = null;
            Session.Abandon();
            return RedirectToRoute(new { area = "", controller = "Home", action = "Index" });
        }
	}
}