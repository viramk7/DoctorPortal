using DoctorPortal.Web.AdminServices.Entity;
using DoctorPortal.Web.Models;
using System;
using System.Collections.Generic;

namespace DoctorPortal.Web.AdminServices.Appointment
{
    public interface IAppointmentService : IEntityService<Database.Appointment>
    {
        IEnumerable<MakeAppointmentViewModel> GetAllAppointmentList();
        MakeAppointmentViewModel ApproveAppointment(int id, DateTime date);
    }
}
