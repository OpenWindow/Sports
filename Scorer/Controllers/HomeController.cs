using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sports.Domain.Abstract;
using Sports.Domain.Entities;

namespace Scorer.Controllers
{
  public class HomeController : Controller
  {
    private IScheduleRepository _scheduleRespository;

    public HomeController(IScheduleRepository scheduleRepository)
    {
      this._scheduleRespository = scheduleRepository;
    }
    public ActionResult Index()
    {
      ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your app description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }

    [Authorize]
    public ViewResult Games()
    {
      ViewBag.Message = "Today's Games";
      return View(_scheduleRespository.Schedule);
    }

    [Authorize]
    public ViewResult GamesForThisWeek()
    {
        var currentDate = DateTime.Now;


        
        return View(_scheduleRespository.Schedule);
    }


  }
}
