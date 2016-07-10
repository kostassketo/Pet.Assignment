using System;
using System.Threading.Tasks;

namespace Pet.Assignment.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IPetOwnerRepository PetOwners { get; }

        IPetRepository Pets { get; }

        IPetWalkerRepository PetWalkers { get; }

        IOwnerWalkerRepository OwnerWalkers { get; }

        Task<int> Complete();
    }
}
