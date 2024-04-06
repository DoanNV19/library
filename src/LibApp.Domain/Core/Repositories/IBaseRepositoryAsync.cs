using LibApp.Domain.Core.Models;
using LibApp.Domain.Core.Specifications;

namespace LibApp.Domain.Core.Repositories
{
    public interface IBaseRepositoryAsync<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IList<T>> ListAllAsync();
        Task<IList<T>> ListAsync(ISpecification<T> spec);
        Task<T?> FirstOrDefaultAsync(ISpecification<T?> spec);
        Task<T> AddAsync(T entity);
        Task<T> AddAsync(T entity, string id);
        void Update(T entity);
        void Update(T entity, string id);
        void Delete(T entity);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}
