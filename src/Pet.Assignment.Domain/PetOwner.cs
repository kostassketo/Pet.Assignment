using System.Collections.Generic;

namespace Pet.Assignment.Domain
{
    public class PetOwner
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual IList<Pet> Pets { get; set; } = new List<Pet>();

        public virtual IList<OwnerWalker> OwnerWalkers { get; set; } = new List<OwnerWalker>(); 
    }
}