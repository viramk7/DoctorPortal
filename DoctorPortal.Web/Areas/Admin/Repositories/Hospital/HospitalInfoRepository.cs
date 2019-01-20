using System;
using System.Data.Entity;
using DoctorPortal.Web.Database;
using DoctorPortal.Web.Database.Repositories;
using Kendo.Mvc.Extensions;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using DoctorPortal.Web.Areas.Admin.Models.ViewModels;

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
            var hospital = Entities.FirstOrDefault(w => w.Id == hospitalId);

            //var hospital = Entities.Where(w => w.Id == hospitalId)
            //                        .Select(s => new
            //                        {
            //                            s,
            //                            s.HospitalContacts,
            //                            s.HospitalWorkingDays
            //                        })
            //                        .AsEnumerable()
            //                        .Select(x => x.s)
            //                        .FirstOrDefault();

            return hospital;
        }

        public void SaveHospitalInfo(HospitalInfoViewModel hospital)
        {
            using (var scope = new TransactionScope())
            {
                var hospitalMaster = Entities.FirstOrDefault(w => w.Id == hospital.HospitalId);

                if (hospitalMaster == null)
                    throw new Exception("No hospital found");

                var hospitalContacts = hospitalMaster.HospitalContacts.ToList();
                //var hospitalContacts = _context.Set<HospitalContact>().Where(w => w.HospitalId == hospital.HospitalId).ToList();
                hospitalContacts.ForEach(c => _context.Set<HospitalContact>().Remove(c));

                var workingDays = hospitalMaster.HospitalWorkingDays.ToList();
                //var workingDays = _context.Set<HospitalWorkingDay>().Where(w => w.HospitalId == hospital.HospitalId).ToList();
                workingDays.ForEach(d => _context.Set<HospitalWorkingDay>().Remove(d));

                var hospitalContact = hospital.ContactNo.Split(',')
                    .Select(s => new HospitalContact { ContactNo = s, IsEmergency = false, HospitalId = hospital.HospitalId })
                    .ToList();

                var emergencyContacts = hospital.EmergencyContact.Split(',')
                    .Select(s => new HospitalContact { ContactNo = s, IsEmergency = true, HospitalId = hospital.HospitalId })
                    .ToList();

                hospitalContact.AddRange(emergencyContacts);

                hospitalMaster.Name = hospital.HospitalName;
                hospitalMaster.Email = hospital.Email;
                hospitalMaster.AddressLine1 = hospital.AddressLine1;
                hospitalMaster.AddressLine2 = hospital.AddressLine2;
                hospitalMaster.WorkingHoursFrom = hospital.WorkingHoursFrom;
                hospitalMaster.WorkingHoursTo = hospital.WorkingHoursTo;
                hospitalMaster.HospitalContacts.AddRange(hospitalContact);
                hospitalMaster.HospitalWorkingDays.AddRange(hospital.GetHospitalWorkingDaysFromProperties());

                _context.SaveChanges();

                scope.Complete();
            }

        }
    }
}