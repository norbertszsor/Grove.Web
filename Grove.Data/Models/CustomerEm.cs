using System.ComponentModel.DataAnnotations;
using Grove.Data.Abstraction;

namespace Grove.Data.Models
{
    public class CustomerEm : Entity<Guid>
    {
        [MaxLength(128)]
        public required string Name { get; set; }

        [MaxLength(128)]
        public required string Email { get; set; }

        [MaxLength(32)]
        public string? Phone { get; set; }

        [MaxLength(264)]
        public string? Address { get; set; }

        [MaxLength(10)]
        public string? Nip { get; set; }

        public bool IsCompany { get; set; }

        public Guid BillingId { get; set; }

        public virtual required BillingEm Billing { get; set; }
    }
}
