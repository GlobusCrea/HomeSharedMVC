using HomeShareDAL;
using HomeSharedMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeSharedMVC.Areas.Admin.Controllers
{
    public class MembreController : Controller
    {
        //
        // GET: /Admin/Membre/
        public ActionResult ZoneMembre()
        {
            return View();
        }

        public ActionResult BiensMbre(int id)
        {
            List<BienEchange> lstBiens = new List<BienEchange>();
            lstBiens = BienEchange.getBiensByMbre(id);
            return View(lstBiens);
        }
	}
}