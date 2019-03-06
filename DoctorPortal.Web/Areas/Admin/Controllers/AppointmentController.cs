using DoctorPortal.Web.AdminServices.Appointment;
using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Common;
using DoctorPortal.Web.Models;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    public class AppointmentController : Controller
    {

        private readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        // GET: Admin/Appointment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KendoRead([DataSourceRequest] DataSourceRequest request)
        {
            if (!request.Sorts.Any())
            {
                request.Sorts.Add(new SortDescriptor("Id", ListSortDirection.Ascending));
            }

            var list = _service.GetAllAppointmentList();

            return Json(list.ToDataSourceResult(request));
        }

        public ActionResult ApproveAppointmentPartial(int Id)
        {
            ApproveAppointment obj = new ApproveAppointment();
            obj.Id = Id;
            return PartialView("_ApproveAppointmentPartial", obj);
        }

        public string ApproveAppointment(ApproveAppointment model)
        {
            if(model.Id > 0)
            {
                MakeAppointmentViewModel result = _service.ApproveAppointment(model.Id, model.ApproveDate);
                if (result != null)
                {
                    var bodyTemplate = Utility.ReadFileToString("~/Template/ApproveAppointment.html");

                    bodyTemplate = bodyTemplate.Replace("[@PORTAL-NAME]", ConfigItems.PortalName);
                    bodyTemplate = bodyTemplate.Replace("[@FULLNAME]", result.Name);
                    bodyTemplate = bodyTemplate.Replace("[@APPROVEDDATE]", result.ApprovedDate.Value.ToString("dd/MM/yyyy hh:mm tt"));

                    EmailHelper.SendMail(result.Email, "Appointment Confirmation", bodyTemplate, true);
                }
                return result.Id.ToString();
            }
            return String.Empty;
        }
    }
}