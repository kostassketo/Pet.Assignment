using Pet.Assignment.Abstractions;
using Pet.Assignment.Domain;

namespace Pet.Assignment.DataAccess
{
    public class PetOwnerRepository : Repository<PetOwner>, IPetOwnerRepository
    {
        public PetOwnerRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}