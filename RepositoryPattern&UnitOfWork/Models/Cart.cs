using RepositoryPattern_UnitOfWork.Models;
using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern_UnitOfWork.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [Required]
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; }
    }

    public class CartItem
    {
        public int Id { get; set; }
        [Required]
        public virtual Product? Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public virtual Cart? Cart { get; set; }
    }
}
