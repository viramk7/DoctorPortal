using DoctorPortal.Web.AdminRepositories.Speciality;
using DoctorPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.AdminServices.Speciality
{
    public class SpecialityService : ISpecialityService
    {
        private readonly ISpecialityRepository _iSpecialityRepository;

        public SpecialityService(ISpecialityRepository iSpecialityRepository)
        {
            _iSpecialityRepository = iSpecialityRepository;
        }

        public List<SpecialityViewModel> GetAllSpeciality() 
        {
            var specialitylist = _iSpecialityRepository.Table.ToList();
            return specialitylist.Select(s => new SpecialityViewModel(s)).ToList();
        }
    }
}