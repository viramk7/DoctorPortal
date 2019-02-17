using DoctorPortal.Web.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Models
{
    public class SpecialityViewModel
    {
        public SpecialityViewModel()
        {

        }

        public SpecialityViewModel(Speciality speciality)
        {
            SpecialityId = speciality.SpecialityId;
            Name = speciality.Name;
            doctorlist = speciality.Doctor.Select(s => new DoctorViewModel(s)).ToList();
        }
        public int SpecialityId { get; set; }
        public string Name { get; set; }
        public List<DoctorViewModel> doctorlist { get; set; }
    }
}