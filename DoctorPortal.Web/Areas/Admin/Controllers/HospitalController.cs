using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorPortal.Web.Controllers;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    public class HospitalController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}