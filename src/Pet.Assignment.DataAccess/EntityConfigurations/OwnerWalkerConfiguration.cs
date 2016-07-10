using System.Data.Entity.ModelConfiguration;
using Pet.Assignment.Domain;

namespace Pet.Assignment.DataAccess.EntityConfigurations
{
    public class OwnerWalkerConfiguration : EntityTypeConfiguration<OwnerWalker>
    {
        public OwnerWalkerConfiguration()
        {
            ToTable("OwnersWalkers");

            HasKey(x => new { x.PetOwnerId, x.PetWalkerId });

            HasRequired(ow => ow.PetOwner)
                .WithMany(po => po.OwnerWalkers)
                .HasForeignKey(ow => ow.PetOwnerId)
                .WillCascadeOnDelete(false);

            HasRequired(ow => ow.PetWalker)
                .WithMany(pw => pw.OwnerWalkers)
                .HasForeignKey(ow => ow.PetWalkerId)
                .WillCascadeOnDelete(false);
        }
    }
}
