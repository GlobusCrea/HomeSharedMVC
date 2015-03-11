using HomeSharedMVC.Helper;
using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeSharedMVC.Helper
{
    public static class ProprioHelper
    {
        public static MvcHtmlString Proprio(this HtmlHelper Origin)
        {
            //<div class="col-lg-7 col-sm-7 ">
            //   <h4>John Smith</h4>
            //</div>

            TagBuilder tagDiv = new TagBuilder("div");
            tagDiv.AddCssClass("col-lg-7 col-sm-7");

            TagBuilder tagH3 = new TagBuilder("h4");
            tagH3.SetInnerText(SessionTools.membre.Nom + " " + SessionTools.membre.Prenom);

            tagDiv.InnerHtml = tagH3.ToString();

            return new MvcHtmlString(tagDiv.ToString());
        }

    }
}