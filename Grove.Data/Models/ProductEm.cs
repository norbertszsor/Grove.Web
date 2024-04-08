using Grove.Data.Abstraction;

namespace Grove.Data.Models
{
    public class ProductEm : Entity<Guid>
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public decimal Tax { get; set; }

        public decimal Discount { get; set; }

        public Guid CategoryId { get; set; }

        public virtual ProductCategoryEm Category { get; set; }
    }
}
