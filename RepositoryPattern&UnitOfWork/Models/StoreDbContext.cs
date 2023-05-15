using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern_UnitOfWork.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerAddress> CustomersAddress { get; set; }
        public DbSet<OrderPayment> OrderPayments { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  modelBuilder.Entity<CustomerAddress>().HasNoKey();
          //  modelBuilder.Entity<OrderPayment>().HasNoKey();
        }
    }
}
