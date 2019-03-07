﻿using DoctorPortal.Web.AdminServices.Entity;
using DoctorPortal.Web.Areas.Admin.Models.ViewModels;
using DoctorPortal.Web.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Areas.Admin.Services.Patient
{
    public interface IPatientService : IEntityService<PatientMaster>
    {
        IEnumerable<PatientViewModel> GetPatientsByIds(string ids);
    }
}