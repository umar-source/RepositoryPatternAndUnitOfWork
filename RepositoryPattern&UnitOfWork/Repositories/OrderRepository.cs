using RepositoryPattern_UnitOfWork.Interfaces;
using RepositoryPattern_UnitOfWork.Models;

namespace RepositoryPattern_UnitOfWork.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }
    }
}
