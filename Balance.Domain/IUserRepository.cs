using System.Threading.Tasks;
using Balance.Domain.Base;
using Balance.Domain.Entities;

namespace Balance.Domain
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByNameAsync(string name);
    }
}