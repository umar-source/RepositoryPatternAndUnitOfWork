using Microsoft.EntityFrameworkCore;
using RepositoryPattern_UnitOfWork.Interfaces;
using RepositoryPattern_UnitOfWork.Models;
using RepositoryPattern_UnitOfWork.Repositories;

namespace RepositoryPattern_UnitOfWork.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _storedbContext;

        public UnitOfWork(
            StoreDbContext storedbContext,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
             IProductRepository productRepository,
              ICustomerAddressRepository customerAddressRepository,
            IOrderPaymentRepository orderPaymentRepository,
             IProductCategoryRepository productCategoryRepository
            )
        {
            _storedbContext = storedbContext;
            CustomerRepo = customerRepository;
            OrderRepo = orderRepository;
            ProductRepo = productRepository;
            CustomerAddressRepo = customerAddressRepository;
            OrderPaymentRepo = orderPaymentRepository;
            ProductCategoryRepo = productCategoryRepository;
        }

        public ICustomerRepository CustomerRepo { get; private set; }

        public IOrderRepository OrderRepo { get; private set; }

        public IProductRepository ProductRepo { get; private set; }

        public ICustomerAddressRepository CustomerAddressRepo { get; private set; }

        public IOrderPaymentRepository OrderPaymentRepo { get; private set; }

        public IProductCategoryRepository ProductCategoryRepo { get; private set; } 

       /* public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            // Get the appropriate repository interface based on the entity type
            if (typeof(TEntity) == typeof(Customer))
            {
                return (IGenericRepository<TEntity>)CustomerRepo;
            }
            else if (typeof(TEntity) == typeof(Product))
            {
                return (IGenericRepository<TEntity>)ProductRepo;
            }
            if (typeof(TEntity) == typeof(CustomerAddress))
            {
                return (IGenericRepository<TEntity>)CustomerAddressRepo;
            }
            else if (typeof(TEntity) == typeof(ProductCategory))
            {
                return (IGenericRepository<TEntity>)ProductCategoryRepo;
            }
            if (typeof(TEntity) == typeof(OrderPayment))
            {
                return (IGenericRepository<TEntity>)OrderPaymentRepo;
            }
            else if (typeof(TEntity) == typeof(Order))
            {
                return (IGenericRepository<TEntity>)OrderRepo;
            }
            // Add other repository interfaces here as needed

            throw new ArgumentException($"No repository found for entity type {typeof(TEntity)}");
        } */


        public void Commit()
        {
            _storedbContext.SaveChanges();
        }

        public void Rollback()
        {
            _storedbContext.Dispose();
        }
    
    }
}
