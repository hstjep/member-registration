using System.Web;
using System.Web.Optimization;

namespace MemberRegistration
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        //"~/Scripts/jquery-{version}.js"
                         "~/Scripts/jquery-1.9.1.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.unobtrusive*",
                    "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        //"~/Scripts/select2.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/respond.js"
                     ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       //"~/Content/select2.css",
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/datepicker.css",
                      "~/Content/site.css"
                      
                       //"~/Content/themes/base/jquery.ui.core.css",
                       // "~/Content/themes/base/jquery.ui.resizable.css",
                       // "~/Content/themes/base/jquery.ui.selectable.css",
                       // "~/Content/themes/base/jquery.ui.accordion.css",
                       // "~/Content/themes/base/jquery.ui.autocomplete.css",
                       // "~/Content/themes/base/jquery.ui.button.css",
                       // "~/Content/themes/base/jquery.ui.dialog.css",
                       // "~/Content/themes/base/jquery.ui.slider.css",
                       // "~/Content/themes/base/jquery.ui.tabs.css",
                       // "~/Content/themes/base/jquery.ui.datepicker.css",
                       // "~/Content/themes/base/jquery.ui.progressbar.css",
                       // "~/Content/themes/base/jquery.ui.theme.css"
                       ));


            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
