using System.Collections.Generic;
using System.Linq;
using DoctorPortal.Web.AdminServices.Entity;
using DoctorPortal.Web.Areas.Admin.Repositories.Testimonials;
using DoctorPortal.Web.Database;
using DoctorPortal.Web.Models;

namespace DoctorPortal.Web.Areas.Admin.Services.Testimonials
{
    public class TestimonialsService : EntityService<Testimonial>, ITestimonialsService
    {
        private readonly ITestimonialsRepository _iTestimonialsRepository;

        public TestimonialsService(ITestimonialsRepository iTestimonialsRepository) : base(iTestimonialsRepository)
        {
            _iTestimonialsRepository = iTestimonialsRepository;
        }

        public IEnumerable<TestimonialViewModel> GetAllTestimonials()
        {
            var testimonials = _iTestimonialsRepository.Table.ToList();
            return testimonials.Select(s => new TestimonialViewModel(s));
        }

        public TestimonialViewModel GetById(int id)
        {
            var testimonial = _iTestimonialsRepository.GetById(id);
            return new TestimonialViewModel(testimonial);
        }

        public TestimonialViewModel Save(TestimonialViewModel model)
        {
            var testimonial = model.GeTestimonialEntity();

            if (testimonial.Id > 0)
            {
                _iTestimonialsRepository.Update(testimonial);
            }
            else
            {
                _iTestimonialsRepository.Insert(testimonial);
                model.Id = testimonial.Id;
            }

            return model;
        }

        public void Delete(int id)
        {
            var testimonial = _iTestimonialsRepository.GetById(id);
            _iTestimonialsRepository.Delete(testimonial);
        }
    }
}