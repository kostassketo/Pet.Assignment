using System;
using System.Collections.Generic;

namespace Pet.Assignment.Domain
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual IList<PetOwner> PetOwners { get; set; } = new List<PetOwner>(); 

        public virtual IList<PetWalker> PetWalkers { get; set; } = new List<PetWalker>();
    }
}