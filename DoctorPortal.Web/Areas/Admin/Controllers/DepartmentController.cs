using DoctorPortal.Web.AdminServices.Department;
using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Areas.Admin.Services.DepartmentImage;
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
    public class DepartmentController : BaseController
    {

        private readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IDepartmentService _service;
        private readonly IDepartmentImageService _imageService;

        private const string FOLDER_PATH = "~/Uploads/Department";

        public DepartmentController(IDepartmentService service, IDepartmentImageService imageService)
        {
            _service = service;
            _imageService = imageService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KendoRead([DataSourceRequest] DataSourceRequest request)
        {
            if (!request.Sorts.Any())
            {
                request.Sorts.Add(new SortDescriptor("DepartmentName", ListSortDirection.Ascending));
            }

            var list = _service.GetAllDepartment();

            return Json(list.ToDataSourceResult(request));
        }

        public ActionResult KendoReadImage([DataSourceRequest] DataSourceRequest request,int departmentId)
        {
            if (!request.Sorts.Any())
            {
                request.Sorts.Add(new SortDescriptor("Id", ListSortDirection.Ascending));
            }

            var list = _imageService.GetAllDepartmentImages(departmentId);

            return Json(list.ToDataSourceResult(request));
        }

        [HttpGet]
        public ActionResult AddEdit(int id = 0)
        {
            var model = new DepartmentViewModel();

            if (id == 0)
                return View(model);

            try
            {
                model = _service.GetDepartmentById(id);
                return View(model);
            }
            catch(Exception ex)
            {
                Logger.log.Error($"Departments > AddEdit. Error: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public ActionResult AddEdit(DepartmentViewModel model,IEnumerable<HttpPostedFileBase> files, string create = null)
        {
            try
            {

                if (model == null || !ModelState.IsValid)
                    return View(model);

                model = _service.Save(model);

                if(files != null)
                {
                    foreach(HttpPostedFileBase file in files)
                    {
                        DepartmentImageViewModel modelfile = new DepartmentImageViewModel();
                        modelfile.DepartmentId = model.DepartmentId;
                        modelfile.ImageName = UploadFile(file);
                        _imageService.Save(modelfile);
                    }
                }

                SuccessNotification(Resources.SaveSuccess);

                if (string.IsNullOrEmpty(create))
                    return RedirectToAction(nameof(Index));

                return create.Equals("Save & Continue")
                    ? RedirectToAction(nameof(AddEdit), new { id = model.DepartmentId })
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

        public ActionResult KendoDestroyImage([DataSourceRequest] DataSourceRequest request, DepartmentImageViewModel model)
        {
            try
            {
                _imageService.Delete(model.Id);
                return Json(new[] { model }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                Logger.log.Error($"DepartmentImage > KendoDestroy. Error: {ex.Message}");
                return Json(new[] { model }.ToDataSourceResult(request, ModelState));
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
            //return fullPath;
            return filename;
        }
    }
}