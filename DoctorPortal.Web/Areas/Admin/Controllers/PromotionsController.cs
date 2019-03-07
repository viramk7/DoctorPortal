using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    public class PromotionsController : BaseController
    {
        public ActionResult Index(string patients = "")
        {
            if (string.IsNullOrEmpty(patients))
                return RedirectToAction("Index","Patient");

            ViewBag.Patients = patients;

            return View();
        }
    }
}