using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Congreso_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int idCongreso)
        {
            ViewData["idCongreso"] = idCongreso;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}