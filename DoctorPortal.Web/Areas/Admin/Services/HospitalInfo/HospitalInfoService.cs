using System;
using System.Linq;
using DoctorPortal.Web.Areas.Admin.Repositories.Hospital;
using DoctorPortal.Web.Database;
using DoctorPortal.Web.Areas.Admin.Models.ViewModels;
using DoctorPortal.Web.Database.Repositories;
using WebGrease.Css.Extensions;

namespace DoctorPortal.Web.Areas.Admin.Services.HospitalInfo
{
    public class HospitalInfoService : IHospitalInfoService
    {
        private readonly IHospitalInfoRepository _hospitalInfoRepository;

        public HospitalInfoService(IHospitalInfoRepository hospitalInfoRepository)
        {
            _hospitalInfoRepository = hospitalInfoRepository;
        }

        public HospitalInfoViewModel GetHospitalById(int hospitalId)
        {
            var hospitalMaster = _hospitalInfoRepository.GetHospitalById(hospitalId);

            var contacts = hospitalMaster.HospitalContacts.Where(w => !w.IsEmergency).Select(s => s.ContactNo);
            var emergencyContacts = hospitalMaster.HospitalContacts.Where(w => w.IsEmergency).Select(s => s.ContactNo);

            var hospitalInfoViewModel = new HospitalInfoViewModel
            {
                HospitalId = hospitalMaster.Id,
                HospitalName = hospitalMaster.Name,
                AddressLine1 = hospitalMaster.AddressLine1,
                AddressLine2 = hospitalMaster.AddressLine2,
                Email = hospitalMaster.Email,
                WorkingHoursFrom = hospitalMaster.WorkingHoursFrom,
                WorkingHoursTo = hospitalMaster.WorkingHoursTo,
                ContactNo = string.Join(", ", contacts),
                EmergencyContact = string.Join(", ", emergencyContacts)
            };

            hospitalInfoViewModel.SetWorkingDaysFromEntity(hospitalMaster.HospitalWorkingDays);

            return hospitalInfoViewModel;
        }

        public void SaveHospitalInfo(HospitalInfoViewModel hospital)
        {
            _hospitalInfoRepository.SaveHospitalInfo(hospital);
        }
    }
}