using Balance.Domain.Base;
using Balance.Domain.Entities;

namespace Balance.Infra.Repository
{
    public class BudgetRepository : BaseRepository<Budget>, IRepository<Budget>
    {
        public BudgetRepository(IMongoContext<Budget> context) : base(context)
        {
        }
    }
}