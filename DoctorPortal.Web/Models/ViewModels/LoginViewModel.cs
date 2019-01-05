using System.ComponentModel.DataAnnotations;

namespace DoctorPortal.Web.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string UserNameOrEmail { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}