using Balance.Domain.Entities;
using MongoDB.Driver;

namespace Balance.Infra
{
    public interface IMongoContext<TEntity> where TEntity : Entity<TEntity>
    {
        IMongoCollection<TEntity> Collection
        {
            get;
        }
    }
}