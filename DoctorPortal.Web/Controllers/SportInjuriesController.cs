using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorPortal.Web.Controllers
{
    public class SportInjuriesController : BaseAdminController
    {   
        public ActionResult Index()
        {
            return View();
        }
    }
}