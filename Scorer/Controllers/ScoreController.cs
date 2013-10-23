using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sports.Domain.Abstract;
using Sports.Domain.Entities;

namespace Scorer.Controllers
{
  [Authorize]
  public class ScoreController : Controller
  {

    public ActionResult Index(int scheduleId)
    {
      return View();
    }

  }
}
