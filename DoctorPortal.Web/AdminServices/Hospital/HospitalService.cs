using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoctorPortal.Web.AdminRepositories.Hospital;
using DoctorPortal.Web.Database;
using DoctorPortal.Web.Models;

namespace DoctorPortal.Web.AdminServices.Hospital
{
    public class HospitalService : IHospitalService
    {
        private readonly  IHospitalRepository _hospitalRepository;

        public HospitalService(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public HospitalViewModel GetHospitalInfo()
        {
            var hospital = _hospitalRepository.GetHospitalInfo();
            if (hospital == null)
                throw new Exception("No hospital found");

            var hospitalViewModel = new HospitalViewModel(hospital);
            
            return hospitalViewModel;
        }
        
    }
}