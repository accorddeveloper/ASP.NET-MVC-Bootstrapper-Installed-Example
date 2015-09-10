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
                      "~/Scripts/js-framework/byId.js",
                      "~/Scripts/js-framework/app.js",
                      "~/Scripts/js-framework/extensions/constants.js",
                      "~/Scripts/js-framework/extensions/urls.js",
                      "~/Scripts/js-framework/extensions/selectors.js",
                      "~/Scripts/js-framework/extensions/initialize.js",
                      "~/Scripts/js-framework/extensions/modal.js",
                      "~/Scripts/js-framework/extensions/pagination.js",
                      "~/Scripts/js-framework/extensions/regularExp.js",
                      "~/Scripts/js-framework/controllers/controllers.js",
                      "~/Scripts/js-framework/controllers/initialize.js",
                      "~/Scripts/js-framework/jQueryExtend.js",
                      "~/Scripts/js-framework/app.js",
                      "~/Scripts/js-framework/app.run.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
