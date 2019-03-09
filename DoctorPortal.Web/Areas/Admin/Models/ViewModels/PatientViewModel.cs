using DoctorPortal.Web.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [UIHint("String")]
        [Display(Name = @"Patient Name")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string Name { get; set; }

        [UIHint("Email")]
        [Display(Name = @"Email Address")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string Email { get; set; }


        public bool Active { get; set; }

        public PatientMaster GetPatientModel()
        {
            return new PatientMaster
            {
                Id = Id,
                Name = Name,
                Email = Email,
                Active = Active
            };
        }
    }
}