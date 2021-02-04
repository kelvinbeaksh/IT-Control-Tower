using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_Control_Tower.Controllers
{
    public class HAMController : Controller
    {
        // GET: HAM
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult newHireDashboard()
        {
            return View();
        }
        public ActionResult pcRefreshDashboard()
        {
            return View();
        }
        public ActionResult bmcAccuracyDashboard()
        {
            return View();
        }
        public ActionResult multiPcDashboard()
        {
            return View();
        }
    }
}