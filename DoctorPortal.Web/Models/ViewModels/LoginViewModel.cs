using System.ComponentModel.DataAnnotations;

namespace DoctorPortal.Web.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = @"User name or Email")]
        [Required(ErrorMessageResourceType = typeof(Resources),ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string UserNameOrEmail { get; set; }

        [Display(Name = @"Password")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}