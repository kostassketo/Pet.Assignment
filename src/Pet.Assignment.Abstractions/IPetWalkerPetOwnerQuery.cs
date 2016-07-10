using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Pet.Assignment.Domain;

namespace Pet.Assignment.Abstractions
{
    public interface IPetWalkerPetOwnerQuery
    {
        Task<IList<OwnerWalker>> GetAsync(Expression<Func<OwnerWalker, bool>> predicate);

        Task<bool> IsApproved(int petWalkerId, int petId);
    }
}
