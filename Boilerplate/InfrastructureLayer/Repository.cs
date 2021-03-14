using Boilerplate.Helpers.Domain;
using Boilerplate.Helpers.Repository;
using Boilerplate.Models.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.InfrastructureLayer
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>
            where TEntity : class, IAggregateRoot<TId>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TEntity> Find()
        {
            return _unitOfWork.Context.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> FindAsync()
        {
            return await _unitOfWork.Context.Set<TEntity>().ToListAsync();
        }

        public TEntity FindById(TId id)
        {
            TEntity entity = _unitOfWork.Context
                .Set<TEntity>()
                .Find(id);

            if (entity == null)
                throw ErrorResponse.NotFound(typeof(TEntity).Name);

            return entity;
        }

        public async Task<TEntity> FindByIdAsync(TId id)
        {
            TEntity entity = await _unitOfWork.Context
                .Set<TEntity>()
                .FindAsync(id);

            if (entity == null)
                throw ErrorResponse.NotFound(typeof(TEntity).Name);

            return entity;
        }

        public void Add(TEntity entity)
        {
            _unitOfWork.Context.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _unitOfWork.Context.Set<TEntity>().AddAsync(entity);
        }

        public void AddList(IEnumerable<TEntity> entitites)
        {
            _unitOfWork.Context.Set<TEntity>().AddRange(entitites);
        }

        public async Task AddListAsync(IEnumerable<TEntity> entitites)
        {
            await _unitOfWork.Context.Set<TEntity>().AddRangeAsync(entitites);
        }

        public TEntity Update(TId id, TEntity UpdateEntity)
        {
            TEntity entity = FindById(id);

            UpdateEntity.SetId(entity.Id);

            foreach (var property in UpdateEntity.GetType().GetProperties())
            {
                if (property.GetValue(UpdateEntity, null) == null)
                {
                    property.SetValue(UpdateEntity, entity.GetType().GetProperty(property.Name)?.GetValue(entity, null));
                }
            }

            _unitOfWork.Context.Entry(entity).CurrentValues.SetValues(UpdateEntity);

            return entity;
        }
        public async Task<TEntity> UpdateAsync(TId id, TEntity UpdateEntity)
        {
            TEntity entity = await FindByIdAsync(id);

            UpdateEntity.SetId(entity.Id);

            foreach (var property in UpdateEntity.GetType().GetProperties())
            {
                if (property.GetValue(UpdateEntity, null) == null)
                {
                    property.SetValue(UpdateEntity, entity.GetType().GetProperty(property.Name)?.GetValue(entity, null));
                }
            }

            _unitOfWork.Context.Entry(entity).CurrentValues.SetValues(UpdateEntity);

            return entity;
        }
        public TEntity Remove(TId id)
        {
            TEntity entity = FindById(id);
            _unitOfWork.Context.Set<TEntity>().Remove(entity);

            return entity;
        }
        public async Task<TEntity> RemoveAsync(TId id)
        {
            TEntity entity = await FindByIdAsync(id);
            _unitOfWork.Context.Set<TEntity>().Remove(entity);

            return entity;
        }
    }
}
