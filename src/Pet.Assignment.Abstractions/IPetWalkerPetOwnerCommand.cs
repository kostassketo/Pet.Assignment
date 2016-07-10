using System.Threading.Tasks;
using Pet.Assignment.Domain;

namespace Pet.Assignment.Abstractions
{
    public interface IPetWalkerPetOwnerCommand
    {
        Task ApproveAsync(PetOwner petOwner, PetWalker petWalker);
    }
}
