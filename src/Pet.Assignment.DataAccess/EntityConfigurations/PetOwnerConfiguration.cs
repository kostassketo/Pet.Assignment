using System.Data.Entity.ModelConfiguration;
using Pet.Assignment.Domain;

namespace Pet.Assignment.DataAccess.EntityConfigurations
{
    public class PetOwnerConfiguration : EntityTypeConfiguration<PetOwner>
    {
        public PetOwnerConfiguration()
        {
            ToTable("PetOwners");

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
