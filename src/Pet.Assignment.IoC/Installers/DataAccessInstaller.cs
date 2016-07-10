using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Pet.Assignment.Abstractions;
using Pet.Assignment.DataAccess;

namespace Pet.Assignment.IoC.Installers
{
    public class DataAccessInstallerr : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container?.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>());
            container?.Register(Component.For<IDbContext>().ImplementedBy<PetTestDbContext>());
            container?.Register(Component.For<IPetWalkerRepository>().ImplementedBy<PetWalkerRepository>());
            container?.Register(Component.For<IPetRepository>().ImplementedBy<PetRepository>());
            container?.Register(Component.For<IPetOwnerRepository>().ImplementedBy<PetOwnerRepository>());
            container?.Register(Component.For<IOwnerWalkerRepository>().ImplementedBy<OwnerWalkerRepository>());
        }
    }
}
