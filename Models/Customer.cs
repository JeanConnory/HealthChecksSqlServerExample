using System.ComponentModel.DataAnnotations;

namespace HealthCheckSample.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? Name { get; set; }

        [Required]
        [StringLength(255)]
        public string? Email{ get; set; }

        public bool IsActive { get; set; }
    }
}
