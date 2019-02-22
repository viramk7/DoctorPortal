using DoctorPortal.Web.Common;
using DoctorPortal.Web.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Models
{
    public class DepartmentViewModel
    {
        public DepartmentViewModel()
        {

        }
        public DepartmentViewModel(Department department)
        {
            DepartmentId = department.DepartmentId;
            HospitalId = department.HospitalId;
            DepartmentName = department.DepartmentName;
            Description = department.Description;
            HomePageIcon = department.HomePageIcon;
            imageslist = department.DepartmentImages.Select(s=>new DepartmentImageViewModel(s)).ToList();
        }
        public int DepartmentId { get; set; }
        public int HospitalId { get; set; }

        [Display(Name = @"Department Name")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string DepartmentName { get; set; }

        [Display(Name = @"Description")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        public string Description { get; set; }

        [Display(Name = @"Home Page Icon")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string HomePageIcon { get; set; }

        public IEnumerable<DepartmentImageViewModel> imageslist { get; set; }
        public IEnumerable<FacilityViewModel> serviceslist { get; set; }

        public Department GetDepartmentEntity()
        {
            return new Department
            {
                DepartmentId = DepartmentId,
                HospitalId = WebHelper.HospitalId,
                DepartmentName = DepartmentName,
                Description = Description,
                HomePageIcon = HomePageIcon
            };
        }
    }
}