using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorPortal.Web.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult Index(Exception error)
        {
            return View();
        }

        public ActionResult HttpError404(Exception error)
        {
            return View();
        }

        public ActionResult HttpError500(Exception error)
        {
            return View();
        }

        public ActionResult General(Exception error)
        {
            return View();
        }


    }
}