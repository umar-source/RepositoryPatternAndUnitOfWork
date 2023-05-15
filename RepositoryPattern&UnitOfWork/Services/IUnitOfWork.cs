using RepositoryPattern_UnitOfWork.Interfaces;

namespace RepositoryPattern_UnitOfWork.Services
{
    public interface IUnitOfWork
    {
        public ICustomerRepository CustomerRepo { get; }

        public IOrderRepository OrderRepo { get; }

        public IProductRepository ProductRepo { get; }

        public ICustomerAddressRepository CustomerAddressRepo { get; }

        public IOrderPaymentRepository OrderPaymentRepo { get; }

        public IProductCategoryRepository ProductCategoryRepo { get; }

       // IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        void Commit();

        void Rollback();
    }
}
