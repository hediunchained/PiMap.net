using System.Web;
using System.Web.Optimization;

namespace IdentityServer

{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));



            bundles.Add(new StyleBundle("~/Content/vendor").Include(
                                    "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                                    "~/Content/vendor/font-awesome/css/font-awesome.min.css",
                                    "~/Content/vendor/chartist/css/chartist.min.css",
                                   "~/Content/vendor/chartist-plugin-tooltip/chartist-plugin-tooltip.css",
                                   "~/Content/css/main.css",
                                   "~/Content/css/color_skins.css",
                                  "~/Content/vendor/toastr/toastr.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(

                        "~/Content/css/main.css",
                        "~/Content/css/color_skins.css"));


            bundles.Add(new StyleBundle("~/Content/vendor/toastr").Include(
                 "~/Content/vendor/toastr/toastr.min.css"));



            bundles.Add(new StyleBundle("~/Content/Bundles").Include(
                         "~/Content/bundles/libscripts.bundle.js",
                          "~/Content/bundles/vendorscripts.bundle.js",
                         "~/Content/bundles/chartist.bundle.js",
                         "~/Content/bundles/knob.bundle.js",
                         "~/Content/bundles/mainscripts.bundle.js"));



            bundles.Add(new StyleBundle("~/Content/js").Include(

                        "~/Content/js/index.js"));

            bundles.Add(new StyleBundle("~/Content/vendor/toastr").Include(

                  "~/Content/vendor/toastr/toastr.js"));
        }
    }
}
