using Pet.Assignment.Abstractions;
using Pet.Assignment.Domain;

namespace Pet.Assignment.DataAccess
{
    public class PetWalkerRepository : Repository<PetWalker>, IPetWalkerRepository
    {
        public PetWalkerRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
