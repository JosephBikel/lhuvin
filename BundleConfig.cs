using System.Web;
using System.Web.Optimization;

namespace Lhuvin
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-1.10.2.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/jquery-ui-1.12.1.min.js",
                        "~/Scripts/jquery.dataTables.min.js",
                        "~/Scripts/dataTables.bootstrap.min.js",
                        "~/Scripts/toastr.min.js",
                        "~/Scripts/bootstrap-select.min.js",
                        "~/Scripts/mobiscroll.jquery.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                      "~/Scripts/site.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.css",
                      "~/Content/bootstrap-rtl.css",
                      "~/Content/bootstrap-icons.css",
                      "~/Content/themes/base/jquery-ui.min.css",
                      "~/Content/toastr.min.css",
                      "~/Content/bootstrap-select.min.css",
                      
                      "~/Content/mobiscroll.jquery.min.css",
                      "~/Content/themes/base/jquery-no-theme-rtl.css",
                      "~/Content/site.css",
                      "~/Content/dataTables.bootstrap.min.css"
                      ));

        }
    }
}
