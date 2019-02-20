using DoctorPortal.Web.AdminRepositories.Appointment;
using DoctorPortal.Web.AdminServices.Entity;

namespace DoctorPortal.Web.AdminServices.Appointment
{
    public class AppointmentService: EntityService<Database.Appointment>, IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository) : base(appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
    }
}