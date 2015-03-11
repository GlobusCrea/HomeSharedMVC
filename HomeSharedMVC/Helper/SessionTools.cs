using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeSharedMVC.Helper
{
    public class SessionTools
    {
        public static Membre membre
        {
            get { return (Membre)HttpContext.Current.Session["membre"]; }
            set { HttpContext.Current.Session["membre"] = value; }
        }
        
        public static string Login
        {
            get
            {
                if (HttpContext.Current.Session["Login"] != null) return HttpContext.Current.Session["Login"].ToString();
                else return null;
            }

            set { HttpContext.Current.Session["Login"] = value; }
        }
    }
}