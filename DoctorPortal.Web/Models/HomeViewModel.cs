using DoctorPortal.Web.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            Facilitylist = hospital.Facilities.Select(s => new FacilityViewModel(s)).ToList();
        }

        public IList<TestimonialViewModel> Testimonials { get; set; }

        public IList<FacilityViewModel> Facilitylist { get; set; }
    }
}