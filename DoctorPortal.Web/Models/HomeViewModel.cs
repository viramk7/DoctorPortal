using DoctorPortal.Web.Database;
using System.Collections.Generic;
using System.Linq;

namespace DoctorPortal.Web.Models
{
    public class HomeViewModel : HospitalViewModel
    {
        public HomeViewModel()
        {

        }

        public HomeViewModel(HospitalMaster hospital)
        {
            Testimonials = hospital.Testimonials.Select(s => new TestimonialViewModel(s)).ToList();
        }

        public IList<TestimonialViewModel> Testimonials { get; set; }
    }
}