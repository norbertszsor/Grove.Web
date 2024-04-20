using Grove.Shared.Abstraction;
using Grove.Transfer.ProductCategory.Data;

namespace Grove.Transfer.ProductCategory.Command
{
    public class UpdateProductCategoryCommand : CreateProductCategoryCommand, ICommand<ProductCategoryDto>
    {
        public Guid Id { get; set; }
    }
}
