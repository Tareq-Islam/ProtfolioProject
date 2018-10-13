using System.Web;
using System.Web.Optimization;

namespace WebFile
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/custom.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            //Admin Js file
            bundles.Add(new ScriptBundle("~/bundles/adminjs").Include(
                "~/Scripts/Adminjs/bootstrap.bundle.min.js",
                "~/Scripts/Adminjs/jquery.easing.min.js",
                "~/Scripts/Adminjs/Chart.min.js",
                "~/Scripts/Adminjs/jquery.dataTables.js",
                "~/Scripts/Adminjs/dataTables.bootstrap4.js",
                "~/Scripts/Adminjs/sb-admin.min.js",
                "~/Scripts/Adminjs/sb-admin-datatables.min.js",
                "~/Scripts/Adminjs/sb-admin-charts.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Admincss/font-awesome.min.css",
                      "~/Content/Admincss/sb-admin.css",
                      "~/Content/Admincss/dataTables.bootstrap4.css"
                ));
        }
    }
}
