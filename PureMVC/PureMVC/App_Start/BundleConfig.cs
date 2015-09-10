using System.Web;
using System.Web.Optimization;

namespace PureMVC {
    public class BundleConfig {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {
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
                      "~/Content/js-framework/byId.js",
                      "~/Content/js-framework/app.js",
                      "~/Content/js-framework/extensions/constants.js",
                      "~/Content/js-framework/extensions/urls.js",
                      "~/Content/js-framework/extensions/selectors.js",
                      "~/Content/js-framework/extensions/initialize.js",
                      "~/Content/js-framework/extensions/modal.js",
                      "~/Content/js-framework/extensions/pagination.js",
                      "~/Content/js-framework/extensions/regularExp.js",
                      "~/Content/js-framework/controllers/controllers.js",
                      "~/Content/js-framework/controllers/homeController.js",
                      "~/Content/js-framework/controllers/initialize.js",
                      "~/Content/js-framework/jQueryExtend.js",
                      "~/Content/js-framework/app.js",
                      "~/Content/js-framework/app.run.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
