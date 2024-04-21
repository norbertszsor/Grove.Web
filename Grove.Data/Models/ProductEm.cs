using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Display(AutoGenerateField = false)]
        public Guid CategoryId { get; set; }

        public byte Region { get; set; }

        public byte[]? Image { get; set; }


        [ForeignKey(nameof(CategoryId))]
        public virtual ProductCategoryEm? Category { get; set; }

        public virtual ICollection<BillingItemEm>? BillingItems { get; set; }
    }
}
