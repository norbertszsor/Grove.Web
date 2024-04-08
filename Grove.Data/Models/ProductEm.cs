using System.ComponentModel.DataAnnotations;
using Grove.Data.Abstraction;

namespace Grove.Data.Models
{
    public class ProductEm : Entity<Guid>
    {
        [MaxLength(128)]
        public required string Name { get; set; }

        [MaxLength(512)]
        public string? Description { get; set; }

        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

        public virtual required ProductCategoryEm Category { get; set; }

        public virtual ICollection<BillingItemEm>? BillingItems { get; set; }
    }
}
