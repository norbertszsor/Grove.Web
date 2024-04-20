using Grove.Transfer.Product.Command;
using Grove.Transfer.Product.Data;

namespace Grove.Logic.Abstraction
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsync(CreateProductCommand command);
        Task<ProductDto> UpdateProductAsync(UpdateProductCommand command);
        Task DeleteProductAsync(DeleteProductCommand command);
    }
}
