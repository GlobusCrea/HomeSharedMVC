using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeSharedMVC.Models
{
    public class WrapperHomePage
    {
        List<BienEchange> _lstBiensMeilleursAvis;
        List<BienEchange> _lstBiensDerniersEchange;

        public List<BienEchange> lstBiensMeilleursAvis
        {
            get { return _lstBiensMeilleursAvis; }
            set { _lstBiensMeilleursAvis = value; }
        }

        public List<BienEchange> lstBiensDerniersEchange
        {
            get { return _lstBiensDerniersEchange; }
            set { _lstBiensDerniersEchange = value; }
        }
    }
}