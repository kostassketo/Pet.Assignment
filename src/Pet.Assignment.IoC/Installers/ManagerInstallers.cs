using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Pet.Assignment.Abstractions;
using Pet.Assignment.Business;
using Pet.Assignment.Domain;

namespace Pet.Assignment.IoC.Installers
{
    public class ManagerInstallers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container?.Register(Component.For<IQuery<PetOwner>>().ImplementedBy<PetOwnerManager>());
            container?.Register(Component.For<IQuery<Domain.Pet>, ICommand<Domain.Pet>>().ImplementedBy<PetManager>());
            container?.Register(Component.For<IQuery<PetWalker>, ICommand<PetWalker>>().ImplementedBy<PetWalkerManager>());
            container?.Register(Component.For<IPetWalkerPetOwnerQuery, IPetWalkerPetOwnerCommand>().ImplementedBy<PetWalkerPetOwnerManager>());
        }
    }
}
