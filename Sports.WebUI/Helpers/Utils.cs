using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports.WebUI.Helpers
{
  public class Utils
  {
    public static IEnumerable<SelectListItem> GetGroupsList()
    {
      var items = new List<SelectListItem>();
      items.Add(new SelectListItem { Text = "1", Value = "1", Selected=true });
      items.Add(new SelectListItem { Text = "2", Value = "2" });
      items.Add(new SelectListItem { Text = "3", Value = "3" });
      items.Add(new SelectListItem { Text = "4", Value = "4" });

      return items;
    }
  }
}