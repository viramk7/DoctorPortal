using DoctorPortal.Web.AdminServices.Entity;
using DoctorPortal.Web.Caching;
using DoctorPortal.Web.Common;
using DoctorPortal.Web.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    public class IconsController : BaseController
    {
        private readonly IEntityService<tblIcons> _service;
        private readonly ICacheManager _cacheManager;

        public IconsController(IEntityService<tblIcons> service,
                               ICacheManager cacheManager)
        {
            _service = service;
            _cacheManager = cacheManager;
        }

        public ActionResult GetIconList()
        {
            var list = _cacheManager.Get(CacheKeys.Flaticons.ToString(), () =>
             {
                 return _service.GetAll().ToList();
             });

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}