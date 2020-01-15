using Balance.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Balance.Infra
{
    public class MongoContext<TEntity> : IMongoContext<TEntity> where TEntity : Entity<TEntity>
    {
        private readonly IMongoDatabase _database;
        public MongoContext(IConfiguration configuration)
        {
            var _connectionString = "mongodb://root:example@localhost/admin";

            var mongoUrl = new MongoUrl(_connectionString);
            var mongoClient = new MongoClient(_connectionString);

            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }
        public IMongoCollection<TEntity> Collection<TEntity>() => _database.GetCollection<TEntity>(typeof(TEntity).Name);
    }
}