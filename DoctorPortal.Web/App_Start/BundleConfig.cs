using System.Web;
using System.Web.Optimization;

namespace DoctorPortal.Web
{
    public class BundleConfig
    {
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // ******************************** FRONT END  ***************************************** //

            // CSS

            bundles.Add(new StyleBundle("~/Content/admincss").Include(
                "~/Content/css/style.css",
                "~/Content/css/responsive.css"));

            // JS

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Content/js/jquery-1.11.1.min.js",
                "~/Content/js/wow.js",
                "~/Content/js/bootstrap.min.js",
                "~/Content/js/jquery.bxslider.min.js",
                "~/Content/js/jquery.countTo.js",
                "~/Content/js/owl.carousel.min.js",
                "~/Content/js/validation.js",
                "~/Content/js/jquery.mixitup.min.js",
                "~/Content/js/jquery.easing.min.js",
                "~/Content/js/jquery.fancybox.pack.js",
                "~/Content/js/jquery.appear.js",
                "~/Content/js/isotope.js",
                "~/Content/js/jquery.prettyPhoto.js",
                "~/Content/js/jquery.bootstrap-touchspin.js",
                "~/Content/assets/timepicker/timePicker.js",
                "~/Content/assets/bootstrap-sl-1.12.1/bootstrap-select.js",
                "~/Content/assets/jquery-ui-1.11.4/jquery-ui.js",
                "~/Content/assets/language-switcher/jquery.polyglot.language.switcher.js",
                "~/Content/assets/html5lightbox/html5lightbox.js"));

            bundles.Add(new ScriptBundle("~/bundles/maps").Include(
                "~/Content/js/gmaps.js",
                "~/Content/js/map-helper.js"));

            bundles.Add(new ScriptBundle("~/bundles/revolution").Include(
                "~/Content/assets/revolution/js/jquery.themepunch.tools.min.js",
                "~/Content/assets/revolution/js/jquery.themepunch.revolution.min.js",
                "~/Content/assets/revolution/js/extensions/revolution.extension.actions.min.js",
                "~/Content/assets/revolution/js/extensions/revolution.extension.carousel.min.js",
                "~/Content/assets/revolution/js/extensions/revolution.extension.kenburn.min.js",
                "~/Content/assets/revolution/js/extensions/revolution.extension.layeranimation.min.js",
                "~/Content/assets/revolution/js/extensions/revolution.extension.migration.min.js",
                "~/Content/assets/revolution/js/extensions/revolution.extension.navigation.min.js",
                "~/Content/assets/revolution/js/extensions/revolution.extension.parallax.min.js",
                "~/Content/assets/revolution/js/extensions/revolution.extension.slideanims.min.js",
                "~/Content/assets/revolution/js/extensions/revolution.extension.video.min.js"));

            // ******************************** /FRONT END ****************************************** //

            BundleTable.EnableOptimizations = false;
        }
    }
}
