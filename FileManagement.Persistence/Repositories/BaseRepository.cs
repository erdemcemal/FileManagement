using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FileManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FileManagement.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly FileManagementDbContext DbContext;

        public BaseRepository(FileManagementDbContext dbContext)
        {
            DbContext = dbContext;
        }

        
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await DbContext.Set<T>().CountAsync();
        }

        public async Task<IReadOnlyList<T>> GetPagedResponseAsync(int page, int size)
        {
            return await DbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await DbContext.Set<T>().AddAsync(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> filterBy)
        {
            return await GetQueryable(filterBy).FirstOrDefaultAsync();
        }

        private IQueryable<T> Table => DbContext.Set<T>();

        private IQueryable<T> GetQueryable(Expression<Func<T, bool>> filterBy = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = Table;

            if (filterBy != null)
            {
                query = query.Where(filterBy);
            }


            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }

    }
}