using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern_UnitOfWork.Models
{
    public class CustomerAddress
    {
        public int Id { get; set; }

        [Required]
        public string? Street { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        public string? State { get; set; }

        [Required]
        public string? Country { get; set; }

        [Required]
        public string? ZipCode { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
