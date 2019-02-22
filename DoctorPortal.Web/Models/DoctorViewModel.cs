using DoctorPortal.Web.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            IsOnHomePage = doctor.IsOnHomePage;
        }

        public int DoctorId { get; set; }
        public int HospitalId { get; set; }

        [Display(Name = @"Name")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string Name { get; set; }

        [Display(Name = @"Position")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string Position { get; set; }

        [DataType(DataType.PhoneNumber , ErrorMessage = "Please provide valid contact No")]
        [Display(Name = @"Contact No")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(12, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string ContactNo { get; set; }

        [Display(Name = @"Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string EmailAddress { get; set; }

        public string ImageName { get; set; }

        [Display(Name = @"Speciality")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        public int SpecialityId { get; set; }

        [Display(Name = @"Doctor Image")]
        [DataType(DataType.Upload)]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        public HttpPostedFileBase ImageFile { get; set; }

        public Nullable<bool> IsOnHomePage { get; set; }

        public Doctor GetDoctorEntity()
        {
            return new Doctor
            {
                DoctorId = DoctorId,
                Name = Name,
                Position = Position,
                ContactNo = ContactNo,
                EmailAddress = EmailAddress,
                ImageName = ImageName ?? Name,
                SpecialityId = SpecialityId,
                IsOnHomePage = IsOnHomePage
            };
        }
    }
}