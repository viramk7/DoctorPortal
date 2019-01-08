﻿using System.Web.Mvc;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    public class AdminHomeController : BaseController
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
    }
}