using System.ComponentModel.DataAnnotations;
using Grove.Shared.Enums;

namespace Grove.Shared.Transfer.Data
{
    public class ProductCategoryDto
    {
        [Required]
        [MaxLength(128)]
        public required string Name { get; set; }

        [Required]
        public ProductType Type { get; set; }
    }
}
