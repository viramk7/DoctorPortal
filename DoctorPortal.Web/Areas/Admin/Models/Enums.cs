using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoctorPortal.Web.Areas.Admin.Models
{
    public static class Enums
    {
        public enum NotifyType
        {
            [Display(Name = "Success")]
            [Description("Success")]
            Success = 1,

            [Display(Name = "Error")]
            [Description("Error")]
            Error = 0
        }
    }
}