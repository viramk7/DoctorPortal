using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoctorPortal.Web.Database;
using DoctorPortal.Web.Database.Repositories;

namespace DoctorPortal.Web.Areas.Admin.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserMaster> _userRepo;

        public UserService(IRepository<UserMaster> userRepo)
        {
            _userRepo = userRepo;
        }

        public IEnumerable<UserMaster> GetAllUsers()
        {
            return _userRepo.Table.ToList(); 
        }

    }
}