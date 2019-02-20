﻿using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Areas.Admin.Services.Doctor;
using DoctorPortal.Web.Common;
using DoctorPortal.Web.Models;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
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
        private readonly IDoctorService _service;

        private const string FOLDER_PATH = "~/Uploads/Doctors";

        public DoctorController(IDoctorService service)
        {
            _service = service;
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

            model = _service.GetById(id);

            return View(model);
        }


        [HttpPost]
        public ActionResult AddEdit(DoctorViewModel model, string create = null)
        {
            try
            {
                if (model == null || !ModelState.IsValid)
                    return View(model);

                if (model.ImageFile != null)
                    model.ImageName = UploadFile(model.ImageFile);

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