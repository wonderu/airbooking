using System.Web.Optimization;

namespace Airbooking.Api
{
    public class BundleConfig
    {
        /// <summary>
        /// group scripts in bundles
        /// </summary>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/vendor/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/vendor/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/underscore").Include(
                "~/Scripts/vendor/underscore.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include("~/Scripts/vendor/angular.js",
                "~/Scripts/vendor/ui-bootstrap.js",
                "~/Scripts/vendor/ui-router.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/vendor/bootstrap.js",
                "~/Scripts/vendor/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.css",
                 "~/Content/font-awesome.css",
                 "~/Content/Site.css"));
        }
    }
}
