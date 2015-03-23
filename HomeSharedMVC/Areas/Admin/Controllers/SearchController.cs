using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeSharedMVC.Areas.Admin.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Admin/Search/
        public ActionResult Search(string strP)
        {
            List<BienEchange> biens = BienEchange.getBiensBystrPays(strP);
            return View(biens);
        }
	}
}