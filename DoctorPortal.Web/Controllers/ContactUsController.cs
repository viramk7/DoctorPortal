using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorPortal.Web.Controllers
{
    public class ContactUsController : BaseAdminController
    {
        // GET: ContactUs
        public ActionResult Index()
        {
            return View();
        }
    }
}