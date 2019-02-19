using DoctorPortal.Web.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.AdminRepositories.Department
{
    public class DepartmentRepository : EfRepository<Database.Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDbContext context) : base(context)
        {

        }

        public Database.Department GetFirstDept()
        {
            return Entities.OrderBy(o => o.DepartmentName).FirstOrDefault();
        }
    }
}