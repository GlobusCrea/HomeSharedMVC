using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeSharedMVC.Models
{
    public class Wrapper
    {
        List<BienEchange> _lstBiensMeilleursAvis;
        List<BienEchange> _lstBiensDerniersEchange;
        List<BienEchange> _lstBienCinqDerniers;
        Membre _mbre;

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

        public List<BienEchange> lstBienCinqDerniers
        {
            get { return _lstBienCinqDerniers; }
            set { _lstBienCinqDerniers = value; }
        }

        public Membre mbre
        {
            get { return _mbre; }
            set { _mbre = value; }
        }
    }
}