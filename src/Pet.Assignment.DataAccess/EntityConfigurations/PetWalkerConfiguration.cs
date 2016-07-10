using System.Data.Entity.ModelConfiguration;
using Pet.Assignment.Domain;

namespace Pet.Assignment.DataAccess.EntityConfigurations
{
    public class PetWalkerConfiguration : EntityTypeConfiguration<PetWalker>
    {
        public PetWalkerConfiguration()
        {
            ToTable("PetWalkers");

            HasKey(p => p.Id);

            Property(x => x.FirstName)
                .IsRequired();
            Property(x => x.LastName)
                .IsRequired();
            Property(x => x.Email)
                .IsRequired();
        }
    }
}
