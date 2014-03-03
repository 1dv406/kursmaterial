using System.Web.Optimization;

namespace GeekCustomer
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"
            ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/app.js"
            ));

            bundles.Add(new StyleBundle("~/Content/themes/simple-lnu").Include(
                "~/Content/reset.css",
                "~/Content/typographic-base.css",
                "~/Content/themes/simple-lnu/site.css"
            ));
        }
    }
}