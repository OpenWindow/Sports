using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sports.Domain.Abstract;

namespace Sports.WebUI.Controllers
{
    public class HomeController : Controller
    {

      private IImageLibrary _imageLibrary;

      public HomeController(IImageLibrary imageLibrary)
      {
        _imageLibrary = imageLibrary;
      }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Aboutus()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        [ChildActionOnly]
        public ActionResult SlideShow()
        {
          return PartialView(_imageLibrary.SlideShowImages);
        }

    }
}
