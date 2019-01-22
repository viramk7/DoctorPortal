using System.Collections.Generic;
using System.Linq;
using DoctorPortal.Web.Areas.Admin.Repositories.Testimonials;
using DoctorPortal.Web.Models;

namespace DoctorPortal.Web.Areas.Admin.Services.Testimonials
{
    public class TestimonialsService : ITestimonialsService
    {
        private readonly ITestimonialsRepository _iTestimonialsRepository;

        public TestimonialsService(ITestimonialsRepository iTestimonialsRepository)
        {
            _iTestimonialsRepository = iTestimonialsRepository;
        }

        public IEnumerable<TestimonialViewModel> GetAllTestimonials()
        {
            var testimonials = _iTestimonialsRepository.Table.ToList();
            return testimonials.Select(s => new TestimonialViewModel(s));
        }

        public void Save(TestimonialViewModel model)
        {
            var testimonial = model.GeTestimonialEntity();

            if (testimonial.Id > 0)
                _iTestimonialsRepository.Update(testimonial);
            else
                _iTestimonialsRepository.Insert(testimonial);
            
        }

        public void Delete(TestimonialViewModel model)
        {
            var testimonial = _iTestimonialsRepository.GetById(model.Id);
            _iTestimonialsRepository.Delete(testimonial);
        }
    }
}