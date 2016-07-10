namespace Pet.Assignment.Domain
{
    public class OwnerWalker
    {
        public OwnerWalker()
        {
            HasApproval = false;
        }

        public int PetOwnerId { set; get; }

        public int PetWalkerId { set; get; }

        public virtual PetOwner PetOwner { get; set; }

        public virtual PetWalker PetWalker { get; set; }

        public bool HasApproval { get; set; }
    }
}
