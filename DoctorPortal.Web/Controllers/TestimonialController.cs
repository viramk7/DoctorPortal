using DoctorPortal.Web.Areas.Admin.Services.Testimonials;
using DoctorPortal.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorPortal.Web.Controllers
{
    public class TestimonialController : Controller
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