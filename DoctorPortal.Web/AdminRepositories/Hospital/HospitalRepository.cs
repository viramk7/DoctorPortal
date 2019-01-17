using System.Data.Entity;
using System.Linq;
using DoctorPortal.Web.Database;
using DoctorPortal.Web.Database.Repositories;

namespace DoctorPortal.Web.AdminRepositories.Hospital
{
    public class HospitalRepository : EfRepository<HospitalMaster>, IHospitalRepository
    {
        public HospitalRepository(IDbContext context) : base(context)
        {
                
        }

        public HospitalMaster GetHospitalInfo()
        {
            var hospital = Entities
                            .Include(i => i.HospitalContacts)
                            .Include(i => i.HospitalWorkingDays)
                            .FirstOrDefault();

            return hospital;
        }
    }
}