using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;                                            

namespace IT_Control_Tower.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        public ActionResult multiPcDashboard()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Hover()
        {
            ViewBag.Message = "Hover page";

            return View();
        }
    }
}