using DoctorPortal.Web.AdminRepositories.Appointment;
using DoctorPortal.Web.AdminServices.Entity;
using DoctorPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoctorPortal.Web.AdminServices.Appointment
{
    public class AppointmentService: EntityService<Database.Appointment>, IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository) : base(appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public IEnumerable<MakeAppointmentViewModel> GetAllAppointmentList()
        {
            var list = _appointmentRepository.Table.ToList();
            return list.Select(s => new MakeAppointmentViewModel(s));
        }

        public int ApproveAppointment(int id, DateTime date,bool isNotifySuccess,string AppointmentRemarks)
        {
            var appointment = _appointmentRepository.GetById(id);
            if (appointment == null)
                throw new Exception("not found");

            appointment.ApprovedDate = date;
            appointment.IsApproved = true;
            appointment.ApproveRemarks = AppointmentRemarks;
            appointment.IsNotifiedSuccess = isNotifySuccess;
            _appointmentRepository.Update(appointment);

            return appointment.Id;
        }
    }
}