using System.Threading.Tasks;
using Pet.Assignment.Abstractions;

namespace Pet.Assignment.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
            PetOwners = new PetOwnerRepository(_dbContext);
            Pets = new PetRepository(_dbContext);
            PetWalkers = new PetWalkerRepository(_dbContext);
            OwnerWalkers = new OwnerWalkerRepository(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IPetOwnerRepository PetOwners { get; }

        public IPetRepository Pets { get; }

        public IPetWalkerRepository PetWalkers { get; }

        public IOwnerWalkerRepository OwnerWalkers { get; }

        public Task<int> Complete()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
