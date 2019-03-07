using DoctorPortal.Web.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Areas.Admin.Models.ViewModels
{
    public class PatientViewModel
    {
        public PatientViewModel()
        {

        }

        public PatientViewModel(PatientMaster patientMaster)
        {
            if(patientMaster != null)
            {
                Id = patientMaster.Id;
                Name = patientMaster.Name;
                Email = patientMaster.Email;
                Active = patientMaster.Active;
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool Active { get; set; }
    }
}