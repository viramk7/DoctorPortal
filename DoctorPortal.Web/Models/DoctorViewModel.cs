using DoctorPortal.Web.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Models
{
    public class DoctorViewModel
    {
        public DoctorViewModel()
        {

        }

        public DoctorViewModel(Doctor doctor)
        {
            DoctorId = doctor.DoctorId;
            Name = doctor.Name;
            Position = doctor.Position;
            ContactNo = doctor.ContactNo;
            EmailAddress = doctor.EmailAddress;
            ImageName = doctor.ImageName;
            SpecialityId = doctor.SpecialityId;
        }

        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string ContactNo { get; set; }
        public string EmailAddress { get; set; }
        public string ImageName { get; set; }
        public int SpecialityId { get; set; }
    }
}