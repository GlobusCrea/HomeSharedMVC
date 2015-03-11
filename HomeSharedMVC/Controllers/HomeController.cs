using HomeShareDAL;
using HomeSharedMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeSharedMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        { 
            WrapperHomePage whp = new WrapperHomePage();
            whp.lstBiensMeilleursAvis = BienEchange.getDernierBien();
            whp.lstBiensDerniersEchange = BienEchange.getDernierBien(); ;
            return View("Index", whp);
        }
    }
}