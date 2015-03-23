using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeSharedMVC.Areas.Admin.Controllers
{
    public class BiensController : Controller
    {
        //
        // GET: /Admin/Biens/
        public ActionResult Details(int id)
        {
            BienEchange bien = BienEchange.getOneBien(id);
            return View(bien);
        }
	}
}