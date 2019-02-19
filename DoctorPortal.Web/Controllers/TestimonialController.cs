using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Areas.Admin.Services.Testimonials;
using DoctorPortal.Web.Common;
using System;
using System.Web.Mvc;

namespace DoctorPortal.Web.Controllers
{
    public class TestimonialController : BaseAdminController
    {
        private readonly ITestimonialsService _service;

        public TestimonialController(ITestimonialsService service)
        {
            _service = service;
        }
        
        public ActionResult Index()
        {
            try
            {
                if (ProjectSession.Hospital == null)
                    throw new Exception("Something went wrong");

                var list = _service.GetAllTestimonials();
                return View(list);
            }
            catch (Exception e)
            {
                Logger.log.Error($"Controller: {nameof(TestimonialController)} , Action: {nameof(Index)}. Error: {e.Message}");
                return View("Error");
            }
        }
    }
}