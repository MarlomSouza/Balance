using System.Threading.Tasks;
using Balance.Domain;
using Balance.Domain.Entities;
using MongoDB.Driver;

namespace Balance.Infra.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoContext<User> context) : base(context) { }

        public async Task<User> GetByNameAsync(string name) => await _collection.Find(x => x.Name.Equals(name)).FirstOrDefaultAsync();
    }
}