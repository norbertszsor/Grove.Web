using Grove.Handling.Abstraction;
using Grove.Logic.Abstraction;
using Grove.Transfer.ProductCategory.Command;
using Grove.Transfer.ProductCategory.Data;

namespace Grove.Handling.CommandHandlers
{
    public class ProductCategoryCommandHandler(IProductCategoryService productCategoryService)
        : ICommandHandler<CreateProductCategoryCommand, ProductCategoryDto>, 
            ICommandHandler<UpdateProductCategoryCommand, ProductCategoryDto>,
            ICommandHandler<DeleteProductCategoryCommand>
    {
        public async Task<ProductCategoryDto> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            return await productCategoryService.CreateProductCategoryAsync(request);
        }

        public async Task<ProductCategoryDto> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            return await productCategoryService.UpdateProductCategoryAsync(request);
        }

        public async Task Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        { 
            await productCategoryService.DeleteProductCategoryAsync(request);
        }
    }
}
