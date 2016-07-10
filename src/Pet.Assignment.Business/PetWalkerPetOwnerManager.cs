using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Pet.Assignment.Abstractions;
using Pet.Assignment.Domain;

namespace Pet.Assignment.Business
{
    public class PetWalkerPetOwnerManager : IPetWalkerPetOwnerQuery, IPetWalkerPetOwnerCommand
    {
        private readonly IUnitOfWork _unitOfWork;

        public PetWalkerPetOwnerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> IsApproved(int petWalkerId, int petId)
        {
            return await _unitOfWork.OwnerWalkers.IsApprovedAsync(petWalkerId, petId);
        }

        public async Task<IList<OwnerWalker>> GetAsync(Expression<Func<OwnerWalker, bool>> predicate)
        {
            return (await _unitOfWork.OwnerWalkers.FindAsync(predicate)).ToList();
        }

        public async Task ApproveAsync(PetOwner petOwner, PetWalker petWalker)
        {
            var petOwnerPetWalker = (await _unitOfWork.OwnerWalkers.FindAsync(x => x.PetOwnerId == petOwner.Id && x.PetWalkerId == petWalker.Id)).FirstOrDefault();

            if (petOwnerPetWalker != null)
            {
                petOwnerPetWalker.HasApproval = true;
                _unitOfWork.OwnerWalkers.Add(petOwnerPetWalker);
            }
        }
    }
}