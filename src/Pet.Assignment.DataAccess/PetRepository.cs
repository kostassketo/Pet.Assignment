using Pet.Assignment.Abstractions;

namespace Pet.Assignment.DataAccess
{
    public class PetRepository : Repository<Domain.Pet>, IPetRepository
    {
        public PetRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
