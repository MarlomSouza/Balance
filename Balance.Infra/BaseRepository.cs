using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Balance.Domain.Base;
using Balance.Domain.Entities;
using MongoDB.Driver;

namespace Balance.Infra
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected readonly IMongoContext<TEntity> _context;
        private readonly IMongoCollection<TEntity> _collection;
        public BaseRepository(IMongoContext<TEntity> context)
        {
            _context = context;
            _collection = _context.Collection<TEntity>();
        }
        public async Task<TEntity> GetByIdAsync(string id) => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _collection.AsQueryable().ToListAsync();

        public async void AddAsync(TEntity entity) => await _collection.InsertOneAsync(entity);

        public async void UpdateAsync(TEntity entity) => await _collection.ReplaceOneAsync(e => e.Id == entity.Id, entity);

        public async void RemoveAsync(TEntity entity) => await _collection.DeleteOneAsync(x => x.Id == entity.Id);
    }
}