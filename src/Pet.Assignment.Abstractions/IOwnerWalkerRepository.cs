using System.Threading.Tasks;
using Pet.Assignment.Domain;

namespace Pet.Assignment.Abstractions
{
    public interface IOwnerWalkerRepository : IRepository<OwnerWalker>
    {
        Task<bool> IsApprovedAsync(int petWalkerId, int petId);
    }
}
