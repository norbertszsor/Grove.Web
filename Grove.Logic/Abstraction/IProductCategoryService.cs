using Grove.Transfer.ProductCategory.Command;
using Grove.Transfer.ProductCategory.Data;

namespace Grove.Logic.Abstraction
{
    public interface IProductCategoryService
    {
        Task<ProductCategoryDto> CreateProductCategoryAsync(CreateProductCategoryCommand command);
        Task<ProductCategoryDto> UpdateProductCategoryAsync(UpdateProductCategoryCommand command);
        Task DeleteProductCategoryAsync(DeleteProductCategoryCommand command);
    }
}
