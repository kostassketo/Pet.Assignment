using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Pet.Assignment.Abstractions;
using Pet.Assignment.Domain;

namespace Pet.Assignment.DataAccess
{
    public class OwnerWalkerRepository : Repository<OwnerWalker>, IOwnerWalkerRepository
    {
        private readonly IDbContext _dbContext;

        public OwnerWalkerRepository(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> IsApprovedAsync(int petWalkerId, int petId)
        {
            var ownerIds =
                await
                    _dbContext.Set<PetOwner>()
                        .Where(o => o.Pets.Any(p => p.Id == petId))
                        .Select(x => x.Id)
                        .ToListAsync();

            return await _dbContext.Set<OwnerWalker>()
                .Select(ow => new { ow.PetOwnerId, ow.HasApproval })
                .AnyAsync(ow => ownerIds.Any(id => id == ow.PetOwnerId) && ow.HasApproval);
        }
    }
}
