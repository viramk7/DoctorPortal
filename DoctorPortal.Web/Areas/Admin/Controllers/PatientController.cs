using DoctorPortal.Web.Areas.Admin.Models.ViewModels;
using DoctorPortal.Web.Areas.Admin.Services.Patient;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using log4net;
using System;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    public class PatientController : BaseController
    {
        private readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IPatientService _patientService;
        
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KendoRead([DataSourceRequest] DataSourceRequest request)
        {
            if (!request.Sorts.Any())
                request.Sorts.Add(new SortDescriptor(nameof(PatientViewModel.Name), ListSortDirection.Ascending));

            var patients = _patientService.GetAll();
            return Json(patients.ToDataSourceResult(request));
        }

        public ActionResult KendoDestroy([DataSourceRequest] DataSourceRequest request, PatientViewModel model)
        {
            try
            {
                _patientService.Delete(model.Id);
                return Json(new[] { model }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                _logger.Error($"Patient > KendoDestroy. Error: {ex.Message}");
                return Json(new[] { model }.ToDataSourceResult(request, ModelState));
            }

        }

        public ActionResult KendoSave([DataSourceRequest] DataSourceRequest request, PatientViewModel model)
        {
            try
            {
                if (model == null || !ModelState.IsValid)
                {
                    return Json(new[] { model }.ToDataSourceResult(request, ModelState));
                }

                model = _patientService.Save(model);

                return Json(new[] { model }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception e)
            {
                _logger.Error($"Patient > KendoSave. Error: {e.Message}");
                ErrorNotification(Resources.SaveFailed);
                return View(model);
            }
        }

        [HttpPost]
        public string ChangeStatus(int id)
        {
            try
            {
                _patientService.ChangeStatus(id);
                return string.Empty;
            }
            catch (Exception ex)
            {
                _logger.Error($"Patient > KendochangeStatus. Error: {ex.Message}");
                return Resources.StatusChangeFailed;
            }
        }
    }
}