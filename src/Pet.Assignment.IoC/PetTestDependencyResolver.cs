using System.Reflection;
using System.Web.Http.Dispatcher;
using Castle.MicroKernel;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Pet.Assignment.IoC
{
    public static class PetTestDependencyResolver
    {
        internal static IWindsorContainer Container { get; private set; }

        internal static Assembly CallingAssembly { get; private set; }

        public static void Register(Assembly callingAssembly)
        {
            Register(callingAssembly, null);
        }

        public static IHttpControllerActivator CreateApiControllerActivator()
        {
            return new PetTestApiControllerActivator(Container);
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static void DisposeContainer()
        {
            Container.Dispose();
        }

        internal static void Register(Assembly callingAssembly, ComponentModelDelegate componentModelDelegate)
        {
            CallingAssembly = callingAssembly;

            var container = new WindsorContainer();
            container.Install(FromAssembly.This(new PetTestInstallerFactory()));
            Container = container;
        }
    }
}
