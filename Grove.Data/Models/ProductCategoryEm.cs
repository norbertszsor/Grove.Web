using Grove.Data.Abstraction;

namespace Grove.Data.Models
{
    public class ProductCategoryEm : Entity<Guid>
    {
        public required string Name { get; set; }

        public byte Type { get; set; }

        public virtual ICollection<ProductEm>? Products { get; set; }
    }
}
