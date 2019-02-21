using DoctorPortal.Web.AdminServices.Appointment;
using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Common;
using DoctorPortal.Web.Models;
using log4net;
using System;
using System.Web.Mvc;

namespace DoctorPortal.Web.Controllers
{
    public class AppointmentController : BaseAdminController
    {
        private readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IAppointmentService _appointmentService;

        public AppointmentController()
        {

        }

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public ActionResult MakeAppointment(MakeAppointmentViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Invalid data");

                var appointment = model.GetAppointmentEntity();
                _appointmentService.Insert(appointment);

                SendEmailToHospital(model);

                return RedirectToAction(nameof(AppointmentRequested), new { success = true });
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return RedirectToAction(nameof(AppointmentRequested), new { success = false });
            }

        }

        [HttpGet]
        public ActionResult AppointmentRequested(bool? success)
        {
            if (success == null)
                RedirectToAction("Index", "Home");

            return View(success);
        }

        private void SendEmailToHospital(MakeAppointmentViewModel model)
        {
            try
            {
                var bodyTemplate = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/Template/Appointment.html"));

                bodyTemplate = bodyTemplate.Replace("[@NAME]", model.Name);
                bodyTemplate = bodyTemplate.Replace("[@EMAIL]", model.Email);
                bodyTemplate = bodyTemplate.Replace("[@MESSAGE]", model.Message);
                bodyTemplate = bodyTemplate.Replace("[@PHONE]", model.PhoneNo ?? "Not provided.");
                bodyTemplate = model.Date == null
                    ? bodyTemplate = bodyTemplate.Replace("[@DATE]", "Not provided.")
                    : bodyTemplate.Replace("[@DATE]", Convert.ToDateTime(model.Date).ToShortDateString());
                               
                EmailHelper.SendAsyncEmail(ProjectSession.Hospital.Email, "Appointment", bodyTemplate, true);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

        }
    }
}