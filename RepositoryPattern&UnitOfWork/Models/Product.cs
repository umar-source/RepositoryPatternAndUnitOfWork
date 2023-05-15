using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPattern_UnitOfWork.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal? Price { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string? Description { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity in stock must be greater than or equal to zero.")]
        public int? QuantityInStock { get; set; }
        [Required]
        public bool IsAvailable { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }

        
    }
}
