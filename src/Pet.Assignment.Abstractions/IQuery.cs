using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pet.Assignment.Abstractions
{
    public interface IQuery<TEntity>
    {
        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetAsync(int id);
    }
}
