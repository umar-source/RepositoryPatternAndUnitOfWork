using RepositoryPattern_UnitOfWork.Interfaces;
using RepositoryPattern_UnitOfWork.Models;

namespace RepositoryPattern_UnitOfWork.Repositories
{
    public class OrderPaymentRepository : GenericRepository<OrderPayment>, IOrderPaymentRepository
    {
        public OrderPaymentRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }
    }
}
