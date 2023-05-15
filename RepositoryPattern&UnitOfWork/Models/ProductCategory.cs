using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern_UnitOfWork.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
