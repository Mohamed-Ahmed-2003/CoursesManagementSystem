using System.Web;
using System.Web.Optimization;

namespace CoursesManagementSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //Data TABLES 
      //      bundles.Add(new StyleBundle("~/bundles/datatables-css").Include(
      //            "https://cdn.datatables.net/1.10.19/js/jquery.dataTables.js",
      //"https://cdn.datatables.net/1.10.18/js/jquery.dataTables.min.js",
      //"https://cdn.datatables.net/1.10.18/js/dataTables.bootstrap4.min.js",
      //"https://cdn.datatables.net/responsive/2.2.3/js/dataTables.responsive.min.js",
      //"https://cdn.datatables.net/responsive/2.2.3/js/responsive.bootstrap.min.js"));

      //      bundles.Add(new ScriptBundle("~/bundles/datatables-js").Include(
      //          "https://cdn.datatables.net/1.10.19/js/jquery.dataTables.js",
      //  "https://cdn.datatables.net/1.10.18/js/jquery.dataTables.min.js",
      //  "https://cdn.datatables.net/1.10.18/js/dataTables.bootstrap4.min.js",
      //  "https://cdn.datatables.net/responsive/2.2.3/js/dataTables.responsive.min.js",
      //  "https://cdn.datatables.net/responsive/2.2.3/js/responsive.bootstrap.min.js"));

        }
    }
}

