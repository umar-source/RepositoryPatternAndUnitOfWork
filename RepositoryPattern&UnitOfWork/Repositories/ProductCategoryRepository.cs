using RepositoryPattern_UnitOfWork.Interfaces;
using RepositoryPattern_UnitOfWork.Models;

namespace RepositoryPattern_UnitOfWork.Repositories
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }
    }
}
