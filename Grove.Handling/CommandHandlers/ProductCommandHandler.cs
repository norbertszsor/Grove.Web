using Grove.Handling.Abstraction;
using Grove.Transfer.Product.Command;
using Grove.Transfer.Product.Data;

namespace Grove.Handling.CommandHandlers
{
    public class ProductCommandHandler : ICommandHandler<CreateProductCommand, ProductDto>,
        ICommandHandler<UpdateProductCommand, ProductDto>,
        ICommandHandler<DeleteProductCommand>
    {
        public Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
