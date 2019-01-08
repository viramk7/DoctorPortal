using System.Collections.Generic;
using DoctorPortal.Web.Database;

namespace DoctorPortal.Web.Areas.Admin.Services.User
{
    public interface IUserService
    {
        IEnumerable<UserMaster> GetAllUsers();
    }
}