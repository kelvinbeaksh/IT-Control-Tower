using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_Control_Tower.Controllers
{
    public class SAMController : Controller
    {
        // GET: SAM
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult softwareAssetTrackerDashboard()
        {
            return View();
        }
        public ActionResult softwareAssetGapDashboard()
        {
            return View();
        }
        public ActionResult abobeCautionaryDashboard()
        {
            return View();
        }
        public ActionResult otherCautionaryDashboard()
        {
            return View();
        }
        public ActionResult multipleOfficeEditionDashboard()
        {
            return View();
        }
    }
}