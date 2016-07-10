using System.Data.Entity.ModelConfiguration;

namespace Pet.Assignment.DataAccess.EntityConfigurations
{
    public class PetConfiguration : EntityTypeConfiguration<Domain.Pet>
    {
        public PetConfiguration()
        {
            ToTable("Pets");

            HasKey(p => p.Id);

            Property(x => x.Name)
                .IsRequired();
            Property(x => x.DateOfBirth)
                .IsRequired();

            HasMany(p => p.PetOwners)
                .WithMany(po => po.Pets)
                .Map(m =>
                {
                    m.ToTable("PetsPetOwners");
                    m.MapLeftKey("PetId");
                    m.MapRightKey("PetOwnerId");
                });

            HasMany(p => p.PetWalkers)
                .WithMany(pw => pw.Pets)
                .Map(m =>
                {
                    m.ToTable("PetsPetWalkers");
                    m.MapLeftKey("PetId");
                    m.MapRightKey("PetWalkerId");
                });
        }
    }
}
