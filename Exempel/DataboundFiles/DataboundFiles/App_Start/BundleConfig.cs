using System.Web.Optimization;

namespace DataboundFiles
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/reset.css",
                "~/Content/typographic-base.css",
                "~/Content/site.css"
            ));
        }
    }
}