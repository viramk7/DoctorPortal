using DoctorPortal.Web.Database.Repositories;

namespace DoctorPortal.Web.AdminRepositories.Appointment
{
    public class AppointmentRepository: EfRepository<Database.Appointment>,IAppointmentRepository
    {
        public AppointmentRepository(IDbContext context) : base(context)
        {
                
        }
    }
}