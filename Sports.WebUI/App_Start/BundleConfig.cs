using System.Web;
using System.Web.Optimization;

namespace Sports.WebUI
{
  public class BundleConfig
  {
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                  "~/Scripts/jquery-2.*"));

      bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                  "~/Scripts/jquery-ui*"));

      bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                  "~/Scripts/jquery.validate*"));

      bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap-select.*",
                  "~/Scripts/bootstrap.*"));

      bundles.Add(new StyleBundle("~/Content/css").Include(
                                 "~/Content/site.css", 
                                 "~/Content/bootstrap.css",
                                 "~/Content/bootstrap-select.css",
                                 "~/Content/bootstrap-theme.css"));

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