using System.ComponentModel.DataAnnotations;

namespace DoctorPortal.Web.Models.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Display(Name = @"Old Password")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string OldPassword { get; set; }

        [Display(Name = @"New Password")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string NewPassword { get; set; }

        [Display(Name = @"Confirm Password")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        [Compare(@"NewPassword",ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "PasswordDoNotMatch")]
        public string ConfirmPassword { get; set; }
    }
}