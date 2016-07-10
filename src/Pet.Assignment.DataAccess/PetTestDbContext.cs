using System.Data.Entity;
using Pet.Assignment.Abstractions;
using Pet.Assignment.DataAccess.EntityConfigurations;
using Pet.Assignment.Domain;

namespace Pet.Assignment.DataAccess
{
    public class PetTestDbContext : DbContext, IDbContext
    {
        public PetTestDbContext() : base("PetTestDBConnectionString")
        {
        }

        public DbSet<Domain.Pet> Pets { get; set; }
        
        public DbSet<PetOwner> PetOwners { get; set; }
        
        public DbSet<PetWalker> PetWalkers { get; set; }

        public DbSet<OwnerWalker> OwnerWalkerPets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PetConfiguration());
            modelBuilder.Configurations.Add(new PetOwnerConfiguration());
            modelBuilder.Configurations.Add(new PetWalkerConfiguration());
            modelBuilder.Configurations.Add(new OwnerWalkerConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
