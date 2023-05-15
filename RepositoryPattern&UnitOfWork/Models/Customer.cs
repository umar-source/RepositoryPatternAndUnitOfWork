using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern_UnitOfWork.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Name length can't be more than 15.")]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Range(18, 70, ErrorMessage = "Age must be between 18 - 70")]
        public string? Age { get; set; }

        [Required]
        [RegularExpression(@"^(\+[0-9]{1,3}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Invalid phone number")]
        public string? Phone { get; set; }
    }
}
