using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Areas.Admin.Services.Testimonials;
using DoctorPortal.Web.Common;
using DoctorPortal.Web.Models;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    public class TestimonialsController : BaseController
    {
        private readonly ITestimonialsService _testimonialsService;

        public TestimonialsController(ITestimonialsService testimonialsService)
        {
            _testimonialsService = testimonialsService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KendoRead([DataSourceRequest] DataSourceRequest request)
        {
            if (!request.Sorts.Any())
            {
                request.Sorts.Add(new SortDescriptor("Name", ListSortDirection.Ascending));
            }

            var testimonials = _testimonialsService.GetAllTestimonials();

            return Json(testimonials.ToDataSourceResult(request));
        }

        public ActionResult KendoSave([DataSourceRequest] DataSourceRequest request, TestimonialViewModel model)
        {
            try
            {
                if (model == null || !ModelState.IsValid)
                    return Json(new[] { model }.ToDataSourceResult(request, ModelState));

                model.HospitalId = ProjectSession.LoggedInUser.HospitalId;
                _testimonialsService.Save(model);

                return Json(GetJson(Resources.SaveSuccess, Enums.NotifyType.Success), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Logger.log.Error($"Testimonials > KendoSave. Error: {e.Message}");
                return Json(GetJson(Resources.SaveFailed, Enums.NotifyType.Error), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult KendoDestroy([DataSourceRequest] DataSourceRequest request, TestimonialViewModel model)
        {
            try
            {
                _testimonialsService.Delete(model);
                return Json(GetJson(Resources.DeleteSuccess, Enums.NotifyType.Success), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Logger.log.Error($"Testimonials > KendoDestroy. Error: {e.Message}");
                return Json(GetJson(Resources.DeleteFailed, Enums.NotifyType.Error), JsonRequestBehavior.AllowGet);
            }       
        }
    }
}