using DoctorPortal.Web.Areas.Admin.Repositories.Facility;
using DoctorPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Areas.Admin.Services.Facility
{
    public class FacilityService : IFacilityService
    {
        private readonly IFacilityRepository _iFacilityRepository;

        public FacilityService(IFacilityRepository iFacilityRepository)
        {
            _iFacilityRepository = iFacilityRepository;
        }

        public IEnumerable<FacilityViewModel> GetAllFacility()
        {
            var facilities = _iFacilityRepository.Table.ToList();
            return facilities.Select(s => new FacilityViewModel(s));
        }

        public FacilityViewModel GetById(int id)
        {
            var facility = _iFacilityRepository.GetById(id);
            return new FacilityViewModel(facility);
        }

        public FacilityViewModel Save(FacilityViewModel model)
        {
            var facility = model.GetFacilityEntity();

            if (facility.FacilityId > 0)
            {
                _iFacilityRepository.Update(facility);
            }
            else
            {
                _iFacilityRepository.Insert(facility);
                model.FacilityId = facility.FacilityId;
            }

            return model;
        }

        public void Delete(int id)
        {
            var facility = _iFacilityRepository.GetById(id);
            _iFacilityRepository.Delete(facility);
        }
    }
}