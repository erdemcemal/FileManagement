using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileManagement.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<int> CountAsync();
        Task<IReadOnlyList<T>> GetPagedResponseAsync(int page, int size);
        Task<T> GetAsync(Expression<Func<T, bool>> filterBy);
    }
}