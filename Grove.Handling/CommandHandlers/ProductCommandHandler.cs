using Grove.Handling.Abstraction;
using Grove.Logic.Abstraction;
using Grove.Transfer.Product.Command;
using Grove.Transfer.Product.Data;

namespace Grove.Handling.CommandHandlers
{
    public class ProductCommandHandler(IProductService productService) : ICommandHandler<CreateProductCommand, ProductDto>,
        ICommandHandler<UpdateProductCommand, ProductDto>,
        ICommandHandler<DeleteProductCommand>
    {
        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return await productService.CreateProductAsync(request);
        }

        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await productService.UpdateProductAsync(request);
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await productService.DeleteProductAsync(request);
        }
    }
}
