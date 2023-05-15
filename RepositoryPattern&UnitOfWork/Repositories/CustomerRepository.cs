using RepositoryPattern_UnitOfWork.Interfaces;
using RepositoryPattern_UnitOfWork.Models;

namespace RepositoryPattern_UnitOfWork.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }
    }
}
