using DoctorPortal.Web.Areas.Admin.Services.Patient;
using DoctorPortal.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    public class PromotionsController : BaseController
    {
        private readonly IPatientService _patientService;

        public PromotionsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public ActionResult Index(string patients = "")
        {
            if (string.IsNullOrEmpty(patients))
                return RedirectToAction("Index","Patient");

            var patientViewModel = _patientService.GetPatientsByIds(patients).ToList();

            return View(patientViewModel);
        }

        // TODO: 1. return model instead form collection
        // Allow admin to insert placeholder for name 
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            var ids = fc["ids"];
            var template = fc["editor"];

            if (string.IsNullOrEmpty(ids) || string.IsNullOrEmpty(template))
                return View();

            var patientViewModel = _patientService.GetPatientsByIds(ids).ToList();

            foreach (var patient in patientViewModel)
            {
                // TODO: Include subject in the form
                EmailHelper.SendAsyncEmail(patient.Email, "Subject", HttpUtility.HtmlDecode(template), true);
            }

            return RedirectToAction("Index", "Patient");
        }
    }
}