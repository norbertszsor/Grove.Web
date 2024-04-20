using System.ComponentModel.DataAnnotations;
using Grove.Data.Abstraction;

namespace Grove.Data.Models
{
    public class ProductEm : Entity
    {
        [MaxLength(128)]
        public required string Name { get; set; }

        [MaxLength(512)]
        public string? Description { get; set; }

        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

        public byte Region { get; set; }

        public virtual ProductCategoryEm? Category { get; set; }

        public virtual ICollection<BillingItemEm>? BillingItems { get; set; }
    }
}
