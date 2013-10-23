using System.Web;
using System.Web.Mvc;

namespace EF_DB_First_Sample
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}