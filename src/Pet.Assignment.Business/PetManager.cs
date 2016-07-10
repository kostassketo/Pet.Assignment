using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Pet.Assignment.Abstractions;

namespace Pet.Assignment.Business
{
    public class PetManager : IQuery<Domain.Pet>, ICommand<Domain.Pet>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PetManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Domain.Pet>> GetAsync(Expression<Func<Domain.Pet, bool>> predicate)
        {
            return (await _unitOfWork.Pets.FindAsync(predicate)).ToList();
        }

        public async Task<Domain.Pet> GetAsync(int id)
        {
            return await _unitOfWork.Pets.GetAsync(id);
        }

        public async Task Create(Domain.Pet entity)
        {
            _unitOfWork.Pets.Add(entity);
            await _unitOfWork.Complete();
        }

        public async Task Update(Domain.Pet entity)
        {
            var pet = await _unitOfWork.Pets.GetAsync(entity.Id);
            pet.DateOfBirth = entity.DateOfBirth;
            pet.Name = entity.Name;

            pet.PetWalkers.Clear();
            foreach (var walker in entity.PetWalkers)
            {
                pet.PetWalkers.Add(walker);
            }

            pet.PetOwners.Clear();
            foreach (var owner in entity.PetOwners)
            {
                pet.PetOwners.Add(owner);
            }

           await _unitOfWork.Complete();
        }
    }
}
