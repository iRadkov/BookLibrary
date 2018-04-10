using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookLib.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "My Online Book Library";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Ivaylo Radkov";

            return View();
        }
    }
}