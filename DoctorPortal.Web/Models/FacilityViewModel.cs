using DoctorPortal.Web.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Models
{
    public class FacilityViewModel
    {
        public FacilityViewModel()
        {
            IsActive = true;
        }

        public FacilityViewModel(Facility facility)
        {
            FacilityId = facility.FacilityId;
            HeaderText = facility.HeaderText;
            Description = facility.Description;
            IconName = facility.IconName;
            HospitalId = facility.HospitalId;
            IsActive = facility.IsActive == null ? false : facility.IsActive.Value;
        }

        [ScaffoldColumn(false)]
        public int FacilityId { get; set; }

        [ScaffoldColumn(false)]
        public int HospitalId { get; set; }

        [UIHint("String")]
        [Display(Name = @"Header")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string HeaderText { get; set; }

        [UIHint("TextArea")]
        [Display(Name = @"Description")]
        [StringLength(500, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string Description { get; set; }

        [Display(Name = @"IconName")]
        [UIHint("IconDropDown")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string IconName { get; set; }

        public bool IsActive { get; set; }

        public Facility GetFacilityEntity()
        {
            return new Facility
            {
                FacilityId = FacilityId,
                HospitalId = HospitalId,
                HeaderText = HeaderText,
                Description = Description,
                IconName = IconName,
                IsActive = IsActive
            };
        }
    }
}