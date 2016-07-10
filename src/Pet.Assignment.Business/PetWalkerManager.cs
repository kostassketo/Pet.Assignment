using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Pet.Assignment.Abstractions;
using Pet.Assignment.Domain;

namespace Pet.Assignment.Business
{
    public class PetWalkerManager : IQuery<PetWalker>, ICommand<PetWalker>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PetWalkerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<PetWalker>> GetAsync(Expression<Func<PetWalker, bool>> predicate)
        {
            return (await _unitOfWork.PetWalkers.FindAsync(predicate)).ToList();
        }

        public async Task<PetWalker> GetAsync(int id)
        {
            return await _unitOfWork.PetWalkers.GetAsync(id);
        }

        public async Task Create(PetWalker entity)
        {
            _unitOfWork.PetWalkers.Add(entity);
            await _unitOfWork.Complete();
        }

        public async Task Update(PetWalker entity)
        {
            var petWalker = await _unitOfWork.PetWalkers.GetAsync(entity.Id);
            petWalker.FirstName = entity.FirstName;
            petWalker.LastName = entity.LastName;
            petWalker.Email = entity.Email;
            petWalker.PhoneNumber = entity.PhoneNumber;

            petWalker.OwnerWalkers.Clear();
            foreach (var ownerWalker in entity.OwnerWalkers)
            {
                petWalker.OwnerWalkers.Add(ownerWalker);
            }

            petWalker.Pets.Clear();
            foreach (var pet in entity.Pets)
            {
                petWalker.Pets.Add(pet);
            }

            await _unitOfWork.Complete();
        }
    }
}
