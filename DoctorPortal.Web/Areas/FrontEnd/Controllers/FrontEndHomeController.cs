using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorPortal.Web.Areas.FrontEnd.Controllers
{
    public class FrontEndHomeController : Controller
    {
        // GET: FrontEnd/FrontEndHome
        public ActionResult Index()
        {
            return View();
        }
    }
}