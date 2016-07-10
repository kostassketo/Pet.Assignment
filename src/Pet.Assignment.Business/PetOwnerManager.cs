using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Pet.Assignment.Abstractions;
using Pet.Assignment.Domain;

namespace Pet.Assignment.Business
{
    public class PetOwnerManager : IQuery<PetOwner>, ICommand<PetOwner>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PetOwnerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<PetOwner>> GetAsync(Expression<Func<PetOwner, bool>> predicate)
        {
            return (await _unitOfWork.PetOwners.FindAsync(predicate)).ToList();
        }

        public async Task<PetOwner> GetAsync(int id)
        {
            return await _unitOfWork.PetOwners.GetAsync(id);
        }

        public async Task Create(PetOwner entity)
        {
            _unitOfWork.PetOwners.Add(entity);
            await _unitOfWork.Complete();
        }

        public async Task Update(PetOwner entity)
        {
            var petOwner = await _unitOfWork.PetOwners.GetAsync(entity.Id);

            petOwner.FirstName = entity.FirstName;
            petOwner.LastName = entity.LastName;
            petOwner.Email = entity.Email;

            petOwner.OwnerWalkers.Clear();
            foreach (var ownerWalker in entity.OwnerWalkers)
            {
                petOwner.OwnerWalkers.Add(ownerWalker);
            }

            petOwner.Pets.Clear();
            foreach (var pet in entity.Pets)
            {
                petOwner.Pets.Add(pet);
            }

            await _unitOfWork.Complete();
        }
    }
}
