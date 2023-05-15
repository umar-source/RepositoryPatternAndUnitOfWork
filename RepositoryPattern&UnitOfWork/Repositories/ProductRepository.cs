using RepositoryPattern_UnitOfWork.Interfaces;
using RepositoryPattern_UnitOfWork.Models;

namespace RepositoryPattern_UnitOfWork.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {

        }
    }
}
