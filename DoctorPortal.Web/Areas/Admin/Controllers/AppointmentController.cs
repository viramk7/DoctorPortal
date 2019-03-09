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

        public ActionResult ApproveAppointmentPartial(int Id)
        {
            var approveAppointment = new ApproveAppointment(Id);
            return PartialView("_ApproveAppointmentPartial", approveAppointment);
        }

        public string ApproveAppointment(ApproveAppointment model)
        {
            if (model.Id > 0)
            {
                var appointment = _service.GetById(model.Id);
                if(appointment != null)
                {
                    var bodyTemplate = Utility.ReadFileToString("~/Template/ApproveAppointment.html");

                    bodyTemplate = bodyTemplate.Replace("[@PORTAL-NAME]", ConfigItems.PortalName);
                    bodyTemplate = bodyTemplate.Replace("[@FULLNAME]", appointment.Name);
                    bodyTemplate = bodyTemplate.Replace("[@APPROVEDDATE]", model.ApproveDate.ToString("dd/MM/yyyy hh:mm tt"));
                    bodyTemplate = bodyTemplate.Replace("[@REMARKS]", model.ApproveRemarks);

                    bool resultNotify = EmailHelper.SendMail(appointment.Email, "Appointment Confirmation", bodyTemplate, true);

                    var result = _service.ApproveAppointment(model.Id, model.ApproveDate,resultNotify,model.ApproveRemarks);
                    return string.Empty;
                }
            }
            return "Something Went Wrong";
        }
    }
}