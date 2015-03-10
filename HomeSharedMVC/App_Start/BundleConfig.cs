using System.Web;
using System.Web.Optimization;

namespace HomeSharedMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /* BUNDLE CSS*/
            //<link rel="stylesheet" href="assets/bootstrap/css/bootstrap.css" />
            //<link rel="stylesheet" href="assets/style.css" />
            //<link rel="stylesheet" href="assets/owl-carousel/owl.carousel.css">
            //<link rel="stylesheet" href="assets/owl-carousel/owl.theme.css">
            //<link rel="stylesheet" type="text/css" href="assets/slitslider/css/style.css" />
            //<link rel="stylesheet" type="text/css" href="assets/slitslider/css/custom.css" />


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/style.css",
                      "~/Content/css/owl.carousel.css",
                      "~/Content/css/owl.theme.css",
                      "~/Content/css/slitsliderStyle.css",
                      "~/Content/css/slitsliderCustom.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
        }
    }
}

    
    //<script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    //<script src="assets/bootstrap/js/bootstrap.js"></script>
    //<script src="assets/script.js"></script>

    //<!-- Owl stylesheet -->
    //<script src="assets/owl-carousel/owl.carousel.js"></script>
    //<!-- Owl stylesheet -->
    
    //<!-- slitslider -->
    
    //<script type="text/javascript" src="assets/slitslider/js/modernizr.custom.79639.js"></script>
    //<script type="text/javascript" src="assets/slitslider/js/jquery.ba-cond.min.js"></script>
    //<script type="text/javascript" src="assets/slitslider/js/jquery.slitslider.js"></script>
    //<!-- slitslider -->