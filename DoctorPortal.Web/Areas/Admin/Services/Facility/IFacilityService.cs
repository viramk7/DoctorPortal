﻿using DoctorPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Areas.Admin.Services.Facility
{
    public interface IFacilityService
    {
        IEnumerable<FacilityViewModel> GetAllFacility();

        IEnumerable<FacilityViewModel> GetAllActiveFacility();

        FacilityViewModel GetById(int id);

        FacilityViewModel Save(FacilityViewModel model);

        void Delete(int id);

        void ChangeStatus(int id);
    }
}