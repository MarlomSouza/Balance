using Balance.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Balance.Infra.Context
{
    public class MongoContext<TEntity> : IMongoContext<TEntity> where TEntity : Entity<TEntity>
    {
        private readonly IMongoDatabase _database;
        public MongoContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }


        public IMongoCollection<TEntity> Collection
        {
            get
            {
                return _database.GetCollection<TEntity>(typeof(TEntity).Name);
            }
        }
    }
}