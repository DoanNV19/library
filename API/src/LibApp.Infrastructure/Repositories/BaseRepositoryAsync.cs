using Microsoft.EntityFrameworkCore;
using LibApp.Infrastructure.Data;
using LibApp.Domain.Core.Specifications;
using LibApp.Domain.Core.Models;
using LibApp.Domain.Core.Repositories;
using System.Linq.Expressions;

namespace LibApp.Infrastructure.Repositories
{
    public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : BaseEntity
    {
        protected readonly LibAppDbContext _dbContext;

        public BaseRepositoryAsync(LibAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] including)
        {
            var query = _dbContext.Set<T>().Where(x => !x.IsDeleted && x.Id == id);

            if (including != null)
            including.ToList().ForEach(include =>
            {
                if (include != null)
                    query = query.Include(include);
            });
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IList<T>> ListAllAsync(params Expression<Func<T, object>>[] including)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            including.ToList().ForEach(include =>
            {
                if (include != null)
                    query = query.Include(include);
            });
            return await query.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<IList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }


        public async Task<IList<T>> ListPagingAsync(ISpecification<T> spec, int PageIndex, int PageSize, params Expression<Func<T, object>>[] including)
        {
            return await ApplySpecification(spec, including).Skip(PageIndex - 1).Take(PageSize).ToListAsync();
        }

        public async Task<T?> FirstOrDefaultAsync(ISpecification<T> spec, params Expression<Func<T, object>>[] including)
        {
            return await ApplySpecification(spec, including).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            entity.CreatedOn = DateTime.Now;
            entity.LastModifiedOn = DateTime.Now;
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity,string id)
        {
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = new Guid(id);
            entity.LastModifiedBy = new Guid(id);
            entity.LastModifiedOn = DateTime.Now;
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Update(T entity)
        {
            entity.LastModifiedOn = DateTime.Now;
            _dbContext.Set<T>().Update(entity);
        }
        public void Update(T entity, string id)
        {
            entity.LastModifiedOn = DateTime.Now;
            entity.LastModifiedBy = new Guid(id);
            _dbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
        
        public async Task Delete(Guid id)
        {
            var entity =  await _dbContext.Set<T>().Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
            if(entity != null)
            {
                entity.IsDeleted = true;
                _dbContext.Set<T>().Update(entity);
            }
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec, params Expression<Func<T, object>>[] including)
        {
            var query = SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
            if (including != null)
            including.ToList().ForEach(include =>
            {
                if (include != null)
                    query = query.Include(include);
            });
            return query.Where(x=>!x.IsDeleted);
        }

    }
}
