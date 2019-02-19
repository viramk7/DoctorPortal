using System.Collections.Generic;
using DoctorPortal.Web.AdminServices.Entity;
using DoctorPortal.Web.Database;
using DoctorPortal.Web.Models;

namespace DoctorPortal.Web.Areas.Admin.Services.Testimonials
{
    public interface ITestimonialsService : IEntityService<Testimonial>
    {
        IEnumerable<TestimonialViewModel> GetAllTestimonials();

        TestimonialViewModel GetById(int id);

        TestimonialViewModel Save(TestimonialViewModel model);

        void Delete(int id);
    }
}
