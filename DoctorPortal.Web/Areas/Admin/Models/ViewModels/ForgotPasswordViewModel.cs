using System.ComponentModel.DataAnnotations;

namespace DoctorPortal.Web.Areas.Admin.Models.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Display(Name = @"Email")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string Email { get; set; }
    }
}