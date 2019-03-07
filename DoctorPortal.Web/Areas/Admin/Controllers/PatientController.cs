using DoctorPortal.Web.Areas.Admin.Models.ViewModels;
using DoctorPortal.Web.Areas.Admin.Services.Patient;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using log4net;
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
    }
}