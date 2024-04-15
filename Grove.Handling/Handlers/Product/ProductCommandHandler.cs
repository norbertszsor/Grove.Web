using Grove.Handling.Abstraction;
using Grove.Shared.Transfer.Commands;

namespace Grove.Handling.Handlers.Product
{
    public class ProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>,
        ICommandHandler<UpdateProductCommand, bool>,
        ICommandHandler<DeleteProductCommand>
    {
        public Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
