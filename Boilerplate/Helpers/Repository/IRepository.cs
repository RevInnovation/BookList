using Boilerplate.Helpers.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Helpers.Repository
{
    public interface IRepository<TEntity, TId>
            where TEntity : class, IAggregateRoot<TId>
    {
        IEnumerable<TEntity> Find();
        Task<IEnumerable<TEntity>> FindAsync();
        TEntity FindById(TId id);
        Task<TEntity> FindByIdAsync(TId id);
        TEntity Update(TId id, TEntity entity);
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void AddList(IEnumerable<TEntity> entity);
        Task AddListAsync(IEnumerable<TEntity> entity);
        void Remove(TEntity entity);
    }
}
