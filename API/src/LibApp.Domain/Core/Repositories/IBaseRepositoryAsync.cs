using LibApp.Domain.Core.Models;
using LibApp.Domain.Core.Specifications;
using System.Linq.Expressions;

namespace LibApp.Domain.Core.Repositories
{
    public interface IBaseRepositoryAsync<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] including);
        Task<IList<T>> ListAllAsync(params Expression<Func<T, object>>[] including);
        Task<IList<T>> ListAsync(ISpecification<T> spec);
        Task<IList<T>> ListPagingAsync(ISpecification<T> spec,int PageIndex, int PageSize, params Expression<Func<T, object>>[] including);
        Task<T?> FirstOrDefaultAsync(ISpecification<T?> spec);
        Task<T> AddAsync(T entity);
        Task<T> AddAsync(T entity, string id);
        void Update(T entity);
        void Update(T entity, string id);
        void Delete(T entity);
        Task Delete(Guid id);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}
