using MongoDB.Driver;

namespace Balance.Infra
{
    public interface IMongoContext<T>
    {
        IMongoCollection<T> Collection<T>();
    }
}