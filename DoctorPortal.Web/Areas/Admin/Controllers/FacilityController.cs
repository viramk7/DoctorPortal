using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Areas.Admin.Services.Facility;
using DoctorPortal.Web.Common;
using DoctorPortal.Web.Models;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    public class FacilityController : BaseController
    {
        private readonly IFacilityService _facilityService;

        public FacilityController(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KendoRead([DataSourceRequest] DataSourceRequest request)
        {
            if (!request.Sorts.Any())
            {
                request.Sorts.Add(new SortDescriptor("HeaderText", ListSortDirection.Ascending));
            }

            var facilitylist = _facilityService.GetAllFacility();

            return Json(facilitylist.ToDataSourceResult(request));
        }

        public ActionResult KendoDestroy([DataSourceRequest] DataSourceRequest request, FacilityViewModel model)
        {
            try
            {
                _facilityService.Delete(model.FacilityId);
                return Json(new[] { model }.ToDataSourceResult(request, ModelState));
            }
            catch(Exception ex)
            {
                Logger.log.Error($"Facility > KendoDestroy. Error: {ex.Message}");
                return Json(new[] { model }.ToDataSourceResult(request, ModelState));
            }
            
        }

        public ActionResult KendoSave([DataSourceRequest] DataSourceRequest request, FacilityViewModel model)
        {
            try
            {
                if (model == null || !ModelState.IsValid)
                {
                    return Json(new[] { model }.ToDataSourceResult(request, ModelState));
                }

                model.HospitalId = ProjectSession.LoggedInUser.HospitalId;
                model = _facilityService.Save(model);

                return Json(new[] { model }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception e)
            {
                Logger.log.Error($"Facility > KendoSave. Error: {e.Message}");
                ErrorNotification(Resources.SaveFailed);
                return View(model);
            }
        }

        //[HttpGet]
        //public ActionResult AddEdit(int id = 0)
        //{
        //    var model = new TestimonialViewModel { HospitalId = ProjectSession.LoggedInUser.HospitalId };
        //    if (id == 0)
        //        return View(model);

        //    model = _testimonialsService.GetById(id);

        //    return View(model);
        //}


        //[HttpPost]
        //public ActionResult AddEdit(TestimonialViewModel model, string create = null)
        //{
        //    try
        //    {
        //        if (model == null || !ModelState.IsValid)
        //            return View(model);

        //        if (model.ClientImage != null)
        //            model.ClientImagePath = UploadFile(model.ClientImage);

        //        model.HospitalId = ProjectSession.LoggedInUser.HospitalId;
        //        model = _testimonialsService.Save(model);

        //        SuccessNotification(Resources.SaveSuccess);

        //        if (string.IsNullOrEmpty(create))
        //            return RedirectToAction(nameof(Index));

        //        return create.Equals("Save & Continue")
        //            ? RedirectToAction(nameof(AddEdit), new { id = model.Id })
        //            : RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception e)
        //    {
        //        Logger.log.Error($"Testimonials > KendoSave. Error: {e.Message}");
        //        ErrorNotification(Resources.SaveFailed);
        //        return View(model);
        //    }
        //}

        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        _testimonialsService.Delete(id);
        //        return Json(GetJson(Resources.DeleteSuccess, Enums.NotifyType.Success), JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception e)
        //    {
        //        Logger.log.Error($"Testimonials > KendoDestroy. Error: {e.Message}");
        //        return Json(GetJson(Resources.DeleteFailed, Enums.NotifyType.Error), JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}