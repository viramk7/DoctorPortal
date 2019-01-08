using Autofac;
using DoctorPortal.Web.Areas.Admin.Services.Login;
using DoctorPortal.Web.Areas.Admin.Services.User;
using DoctorPortal.Web.Database;
using DoctorPortal.Web.Database.Repositories;

namespace DoctorPortal.Web
{
    public class ServiceDependencyRegister
    {
        public static void Resolve(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerDependency();
            builder.RegisterType<DoctorPortalDBEntities>().As<IDbContext>().InstancePerDependency();

            // Services
            builder.RegisterType<LoginService>().As<ILoginService>().InstancePerDependency();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();

        }
    }
}