using DoctorPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.AdminServices.Speciality
{
    public interface ISpecialityService
    {
        List<SpecialityViewModel> GetAllSpeciality();
    }
}