using DoctorPortal.Web.AdminServices.FAQ;
using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Common;
using DoctorPortal.Web.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorPortal.Web.Controllers
{
    public class FAQController : BaseAdminController
    {
        private readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IFAQService _faqService;

        public FAQController()
        {

        }

        public FAQController(IFAQService service)
        {
            _faqService = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MakeFAQQuestion(FAQQuestionsViewModel model)
        {
            try
            {
                 if (!ModelState.IsValid)
                    throw new Exception("Invalid data");

                var faq = model.GetFAQQuestionsEntity();
                _faqService.Insert(faq);

                model.DepartmentName = ProjectSession.Hospital.Departmentlist.FirstOrDefault(m => m.DepartmentId == faq.DepartmentId).DepartmentName;
                SendEmailToHospital(model);

                return RedirectToAction(nameof(FAQRequested), new { success = true });
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return RedirectToAction(nameof(FAQRequested), new { success = false });
            }
        }

        [HttpGet]
        public ActionResult FAQRequested(bool? success)
        {
            if (success == null)
                RedirectToAction("Index", "Home");

            return View(success);
        }

        private void SendEmailToHospital(FAQQuestionsViewModel model)
        {
            try
            {
                var bodyTemplate = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/Template/FAQQuestion.html"));

                bodyTemplate = bodyTemplate.Replace("[@NAME]", model.Name);
                bodyTemplate = bodyTemplate.Replace("[@EMAIL]", model.Email);
                bodyTemplate = bodyTemplate.Replace("[@SUBJECT]", model.Subject);
                bodyTemplate = bodyTemplate.Replace("[@DEPARTMENT]", model.DepartmentName ?? "Not provided.");
                bodyTemplate = bodyTemplate.Replace("[@QUESTION]", model.QuestionText ?? "Not provided.");

                EmailHelper.SendAsyncEmail(ProjectSession.Hospital.Email, "FAQ Question", bodyTemplate, true);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

        }
    }
}