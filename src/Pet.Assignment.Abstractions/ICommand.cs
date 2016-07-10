using System.Threading.Tasks;

namespace Pet.Assignment.Abstractions
{
    public interface ICommand<TEntity>
    {
        Task Create(TEntity entity);

        Task Update(TEntity entity);
    }
}
