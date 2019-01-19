using System.Data.Entity;
using DoctorPortal.Web.Database;
using DoctorPortal.Web.Database.Repositories;
using Kendo.Mvc.Extensions;
using System.Linq;

namespace DoctorPortal.Web.Areas.Admin.Repositories.Hospital
{
    public class HospitalInfoRepository : EfRepository<HospitalMaster>, IHospitalInfoRepository
    {
        private readonly IDbContext _context;

        public HospitalInfoRepository(IDbContext context) : base(context)
        {
            _context = context;
        }
        
        public HospitalMaster GetHospitalById(int hospitalId)
        {
            var hospital = Entities.Where(w => w.Id == hospitalId)
                                    .Select(s => new
                                    {
                                        s,
                                        s.HospitalContacts,
                                        s.HospitalWorkingDays
                                    })
                                    .AsEnumerable()
                                    .Select(x => x.s)
                                    .FirstOrDefault();

            return hospital;
        }
    }
}