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
    public class AppointmentController : BaseController
    {

        private readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
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
                request.Sorts.Add(new SortDescriptor("Id", ListSortDirection.Ascending));
            }

            var list = _service.GetAllAppointmentList();

            return Json(list.ToDataSourceResult(request));
        }

        // TODO: Take Doctor comment prop in ApproveAppointment model
        // Send this instructions with the notification email to patient
        // Also store this in db
        public ActionResult ApproveAppointmentPartial(int Id)
        {
            var approveAppointment = new ApproveAppointment(Id);
            return PartialView("_ApproveAppointmentPartial", approveAppointment);
        }

        public string ApproveAppointment(ApproveAppointment model)
        {
            if (model.Id > 0)
            {
                var result = _service.ApproveAppointment(model.Id, model.ApproveDate);
                if (result != null)
                {
                    var bodyTemplate = Utility.ReadFileToString("~/Template/ApproveAppointment.html");

                    bodyTemplate = bodyTemplate.Replace("[@PORTAL-NAME]", ConfigItems.PortalName);
                    bodyTemplate = bodyTemplate.Replace("[@FULLNAME]", result.Name);
                    bodyTemplate = bodyTemplate.Replace("[@APPROVEDDATE]", result.ApprovedDate.Value.ToString("dd/MM/yyyy hh:mm tt"));

                    // TODO: if confirmation email fails then take one flag "notified" in the db table
                    // and update it to false. by this doctor will know that the patient is not notified 
                    // about the appointment by email so hospital can call the patient.
                    EmailHelper.SendMail(result.Email, "Appointment Confirmation", bodyTemplate, true);
                }

                // TODO: "result" can be null here. Possible null exception
                return result.Id.ToString();
            }
            return string.Empty;
        }
    }
}