using System.ComponentModel.DataAnnotations;
using Grove.Shared.Enums;

namespace Grove.Transfer.ProductCategory.Data
{
    public class ProductCategoryDto
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(128)]
        public required string Name { get; set; }

        [Required]
        public ProductType Type { get; set; }
    }
}
