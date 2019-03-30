using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Areas.Admin.Services.Testimonials;
using DoctorPortal.Web.Caching;
using DoctorPortal.Web.Common;
using DoctorPortal.Web.Database;
using DoctorPortal.Web.Models;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    public class TestimonialsController : BaseController
    {
        private readonly ITestimonialsService _testimonialsService;
        private readonly ICacheManager _cacheManager;

        private const string FOLDER_PATH = "~/Uploads/Testimonials";

        public TestimonialsController(ITestimonialsService testimonialsService,
                                      ICacheManager cacheManager)
        {
            _testimonialsService = testimonialsService;
            _cacheManager = cacheManager;
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

        [HttpGet]
        public ActionResult AddEdit(int id = 0)
        {
            var model = new TestimonialViewModel { HospitalId = ProjectSession.LoggedInUser.HospitalId };
            if (id == 0)
                return View(model);

            model = _testimonialsService.GetById(id);

            return View(model);
        }


        [HttpPost]
        public ActionResult AddEdit(TestimonialViewModel model, string create = null)
        {
            try
            {
                if (model == null || !ModelState.IsValid)
                    return View(model);

                if (model.ClientImage != null)
                    model.ClientImagePath = UploadFile(model.ClientImage);

                model.HospitalId = ProjectSession.LoggedInUser.HospitalId;
                model = _testimonialsService.Save(model);

                // Clear the cache
                _cacheManager.Remove(CacheKeys.TestimonialList.ToString());

                SuccessNotification(Resources.SaveSuccess);

                if (string.IsNullOrEmpty(create))
                    return RedirectToAction(nameof(Index));

                return create.Equals("Save & Continue")
                    ? RedirectToAction(nameof(AddEdit), new { id = model.Id })
                    : RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Logger.log.Error($"Testimonials > KendoSave. Error: {e.Message}");
                ErrorNotification(Resources.SaveFailed);
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _testimonialsService.Delete(id);
                return Json(GetJson(Resources.DeleteSuccess, Enums.NotifyType.Success), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Logger.log.Error($"Testimonials > KendoDestroy. Error: {e.Message}");
                return Json(GetJson(Resources.DeleteFailed, Enums.NotifyType.Error), JsonRequestBehavior.AllowGet);
            }
        }

        public string UploadFile(HttpPostedFileBase file)
        {
            if (file == null)
                return string.Empty;

            var ext = Path.GetExtension(file.FileName);
            if (!WebHelper.ValidImageFileTypes.Contains(ext))
                throw new Exception("File type not valid.");

            if (!Directory.Exists(Server.MapPath(FOLDER_PATH)))
                Directory.CreateDirectory(Server.MapPath(FOLDER_PATH));

            var filename = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var fullPath = $"{FOLDER_PATH}/{filename}";

            file.SaveAs(Server.MapPath(fullPath));
            return fullPath;

        }
    }
}