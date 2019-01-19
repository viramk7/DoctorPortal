using DoctorPortal.Web.Database;

namespace DoctorPortal.Web.Areas.Admin.Models
{
    public class LoggedInUserModel
    {
        public LoggedInUserModel()
        {
            
        }

        public LoggedInUserModel(UserMaster user)
        {
            Id = user.Id;
            FullName = user.FullName;
            UserName = user.UserName;
            Email = user.Email;
            IsSystemGeneratedPassword = user.IsSystemGeneratedPassword;
            RoleId = user.RoleId;
            IsSuperAdmin = user.IsSuperAdmin;
            HospitalId = user.HospitalId;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsSystemGeneratedPassword { get; set; }
        public int RoleId { get; set; }
        public bool IsSuperAdmin { get; set; }
        public int HospitalId { get; set; }
    }
}