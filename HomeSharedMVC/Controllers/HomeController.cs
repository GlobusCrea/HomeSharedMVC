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
        public ActionResult Design()
        {
            return View();
        }
        
        public ActionResult Index()
        { 
            Wrapper whp = new Wrapper();
            whp.lstBiensMeilleursAvis = BienEchange.getDernierBien();
            whp.lstBiensDerniersEchange = BienEchange.getDernierBien();
            return View("Index", whp);
        }

        public ActionResult lstMembres()
        {
            List<Membre> lstMbres = new List<Membre>();
            lstMbres = Membre.getAllMembres();
            return View(lstMbres);
        }
    }
}