using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Balance.Domain.Entities;

namespace Balance.Domain.Base
{
    public interface IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        Task<TEntity> GetByIdAsync(string id);
        void AddAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        void RemoveAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}