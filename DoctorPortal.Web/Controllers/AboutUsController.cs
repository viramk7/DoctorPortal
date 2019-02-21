using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorPortal.Web.Controllers
{
    public class AboutUsController : BaseAdminController
    {
        // GET: AboutUs
        public ActionResult Index()
        {
            return View();
        }
    }
}