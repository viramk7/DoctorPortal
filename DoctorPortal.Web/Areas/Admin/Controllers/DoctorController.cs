using DoctorPortal.Web.AdminServices.Speciality;
using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Areas.Admin.Services.Doctor;
using DoctorPortal.Web.Common;
using DoctorPortal.Web.Models;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    public class DoctorController : BaseController
    {
        private readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IDoctorService _service;
        private readonly ISpecialityService _serviceSpeciality;

        private const string FOLDER_PATH = "~/Uploads/Doctors";

        public DoctorController(IDoctorService service, ISpecialityService serviceSpeciality)
        {
            _service = service;
            _serviceSpeciality = serviceSpeciality;
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

            var list = _service.GetAllDoctorList();

            return Json(list.ToDataSourceResult(request));
        }

        [HttpGet]
        public ActionResult AddEdit(int id = 0)
        {
            var model = new DoctorViewModel();
            if (id == 0)
                return View(model);
            try
            {
                model = _service.GetById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                Logger.log.Error($"Doctors > AddEdit. Error: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }

        }


        [HttpPost]
        public ActionResult AddEdit(DoctorViewModel model, string create = null)
        {
            try
            {
                if (model == null || !ModelState.IsValid)
                    return View(model);

                if (model.ImageFile == null && string.IsNullOrEmpty(model.ImageName))
                {
                    ModelState.AddModelError("ImageName", "Please Upload Doctor Image");
                    return View(model);
                }
                else if (model.ImageFile != null)
                {
                    model.ImageName = UploadFile(model.ImageFile);
                }

                model = _service.Save(model);

                SuccessNotification(Resources.SaveSuccess);

                if (string.IsNullOrEmpty(create))
                    return RedirectToAction(nameof(Index));

                return create.Equals("Save & Continue")
                    ? RedirectToAction(nameof(AddEdit), new { id = model.DoctorId })
                    : RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Logger.log.Error($"Doctors > KendoSave. Error: {e.Message}");
                ErrorNotification(Resources.SaveFailed);
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Json(GetJson(Resources.DeleteSuccess, Enums.NotifyType.Success), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Logger.log.Error($"Doctors > KendoDestroy. Error: {e.Message}");
                return Json(GetJson(Resources.DeleteFailed, Enums.NotifyType.Error), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public string ChangeStatus(int id)
        {
            try
            {
                _service.ChangeStatus(id);
                return string.Empty;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return Resources.StatusChangeFailed;
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

        public ActionResult BindSpecialityDropDown()
        {
            var speciality = _serviceSpeciality.GetAllSpeciality().Select(m => new { m.SpecialityId, m.Name }).ToList();
            return Json(speciality, JsonRequestBehavior.AllowGet);
        }
    }
}