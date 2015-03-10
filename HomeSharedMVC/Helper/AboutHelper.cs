using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeSharedMVC.Helper
{
    public static class AboutHelper
    {
        public static MvcHtmlString About(this HtmlHelper Origin)
        {
            //<div class="col-lg-6 col-sm-9 recent-view">
            //    <h3>A Propos</h3>
            //    <p>The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. 
            //    Sections 1.10.32 and 1.10.33 from "de Finibus Bonorum et Malorum" by Cicero are also reproduced in their exact original form, 
            //    accompanied by English versions from the 1914 translation by H. Rackham.</p>
            //</div>

            TagBuilder tagDiv = new TagBuilder("div");
            tagDiv.AddCssClass("col-lg-6 col-sm-9 recent-view");

            TagBuilder tagH3 = new TagBuilder("h3");
            tagH3.SetInnerText("A Propos");

            TagBuilder tagP = new TagBuilder("p");
            tagP.SetInnerText("Examen de fin de formation en ASP.NET des WAD14");

            tagDiv.InnerHtml = tagH3.ToString();
            tagDiv.InnerHtml += tagP.ToString();
            
            return new MvcHtmlString(tagDiv.ToString());
        }
    }
}