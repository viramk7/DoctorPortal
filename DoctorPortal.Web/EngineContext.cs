using Autofac;
using Autofac.Integration.Mvc;

namespace DoctorPortal.Web
{
    public static class EngineContext
    {
        public static T Resolve<T>()
        {
            return AutofacDependencyResolver.Current.RequestLifetimeScope.Resolve<T>();
        }
    }
}