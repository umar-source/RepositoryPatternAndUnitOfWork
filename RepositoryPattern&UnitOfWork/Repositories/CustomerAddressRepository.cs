using RepositoryPattern_UnitOfWork.Interfaces;
using RepositoryPattern_UnitOfWork.Models;

namespace RepositoryPattern_UnitOfWork.Repositories
{
    public class CustomerAddressRepository :  GenericRepository<CustomerAddress>, ICustomerAddressRepository
    {
        public CustomerAddressRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }
    }
}
