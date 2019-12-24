using System.Web;
using System.Web.Optimization;

namespace GiupviecPalmy_com
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
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

            bundles.Add(new StyleBundle("~/Content/Site/css").Include("~/Content/Site/layout.css",
                "~/Content/Site/top-header.css",
                "~/Content/Site/center-header.css",
                "~/Content/Site/bottom-header.css",
                "~/Content/Site/main-menu.css",
                "~/Content/Site/top-main.css",
                "~/Content/Site/left-main.css",
                "~/Content/Site/middle-main.css",
                "~/Content/Site/right-main.css",
                "~/Content/Site/bottom-main.css",
                "~/Content/Site/side-bar.css",
                "~/Content/Site/top-footer.css",
                "~/Content/Site/center-footer.css",
                "~/Content/Site/bottom-footer.css",
                "~/Content/Site/styles.css",
                "~/Content/Site/font-awesome.css"));
                
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css",
                "~/Content/style.css",
                "~/Content/bootstrap.css",
                "~/Content/jquery-ui.css",
                "~/Content/compact.css",
                "~/Content/views.css",
                "~/Content/top-member.css",
                "~/Content/PagedListHome.css",
                "~/Content/colorbox.css",
                "~/Content/screen.css",
                "~/Content/tooltips.css",
                "~/Content/smoothDivScroll.css",
                "~/Content/gallery.css",
                "~/Content/nivo-slider.css"));
                
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
        }
    }
}