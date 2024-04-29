using Grove.Transfer.ProductCategory.Data;
using Grove.Transfer.ProductRegion.Data;

namespace Grove.Transfer.Product.Data
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

        public Guid RegionId { get; set; }

        public Guid ImageId { get; set; }

        public virtual required ProductCategoryDto Category { get; set; }

        public virtual ProductRegionDto? Region { get; set; }
    }
}
