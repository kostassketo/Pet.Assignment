using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Pet.Assignment.IoC.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (container == null)
            {
                return;
            }

            var assembly = PetTestDependencyResolver.CallingAssembly;
            container.Register(Classes.FromAssembly(assembly).InNamespace("Pet.Assignment.WebServices.Controllers").LifestyleTransient());
        }
    }
}
