using DoctorPortal.Web.AdminServices.Entity;
using DoctorPortal.Web.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    public class IconsController : Controller
    {
        private readonly IEntityService<tblIcons> _service;

        public IconsController(IEntityService<tblIcons> service)
        {
            _service = service;
        }

        public ActionResult GetIconList()
        {
            List<tblIcons> list = _service.GetAll().ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}