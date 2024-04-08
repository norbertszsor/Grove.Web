using Grove.Data.Abstraction;

namespace Grove.Data.Models
{
    public class ProductEm : Entity<Guid>
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

        public virtual required ProductCategoryEm Category { get; set; }
    }
}
