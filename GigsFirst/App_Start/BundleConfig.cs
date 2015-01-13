using System.Web;
using System.Web.Optimization;

namespace GigsFirst
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            // KENDO BUNDLES

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo-web").Include(
                        "~/Scripts/kendo.web.min.js",
                        "~/Scripts/kendo.aspnetmvc.min.js",
                        "~/Scripts/kendo.timezones.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo-dataviz").Include(
                        "~/Scripts/kendo.all.min.js",
                        "~/Scripts/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo-mobile").Include(
                        "~/Scripts/kendo.all.min.js",
                        "~/Scripts/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/demo").Include(
                        "~/Scripts/console.min.js",
                        "~/Scripts/prettify.min.js"));

            bundles.Add(new StyleBundle("~/Content/web/css").Include(
                        "~/Content/web/kendo.common.min.css",
                        "~/Content/web/kendo.rtl.min.css",
                        "~/Content/web/kendo.default.min.css"));

            bundles.Add(new StyleBundle("~/Content/dataviz/css").Include(
                        "~/Content/dataviz/kendo.dataviz.min.css",
                        "~/Content/dataviz/kendo.dataviz.default.min.css"));

            bundles.Add(new StyleBundle("~/Content/mobile/css").Include(
                        "~/Content/mobile/kendo.mobile.all.min.css"));

            bundles.Add(new StyleBundle("~/Content/shared/css").Include(
                        "~/Content/shared/examples-offline.css"));
        }
    }
}