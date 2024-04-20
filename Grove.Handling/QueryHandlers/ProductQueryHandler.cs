using Grove.Handling.Abstraction;
using Grove.Shared.Abstraction;
using Grove.Transfer.Product.Data;
using Grove.Transfer.Product.Query;
using MediatR;

namespace Grove.Handling.QueryHandlers
{
    public class ProductQueryHandler : IQueryHandler<GetProductQuery, ProductDto>,
        IPagedQueryHandler<GetProductListQuery, ProductDto>
    {
        public Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IPagedList<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
