using System.ComponentModel.DataAnnotations;
using Grove.Shared.Abstraction;
using Grove.Shared.Enums;
using Grove.Transfer.Product.Data;

namespace Grove.Transfer.ProductCategory.Command
{
    public class CreateProductCategoryCommand : ICommand<ProductDto>
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public ProductType Type { get; set; }
    }
}
