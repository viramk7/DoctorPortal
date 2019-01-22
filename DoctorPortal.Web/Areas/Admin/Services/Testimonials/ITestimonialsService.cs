using System.Collections.Generic;
using DoctorPortal.Web.Models;

namespace DoctorPortal.Web.Areas.Admin.Services.Testimonials
{
    public interface ITestimonialsService
    {
        IEnumerable<TestimonialViewModel> GetAllTestimonials();

        void Save(TestimonialViewModel model);

        void Delete(TestimonialViewModel model);
    }
}
