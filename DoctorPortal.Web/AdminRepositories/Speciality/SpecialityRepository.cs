using DoctorPortal.Web.Database.Repositories;
using DoctorPortal.Web.Database;
using System.Collections.Generic;

namespace DoctorPortal.Web.AdminRepositories.Speciality
{
    public class SpecialityRepository : EfRepository<Database.Speciality> , ISpecialityRepository
    {
        public SpecialityRepository(IDbContext context) : base(context)
        {

        }
    }
}