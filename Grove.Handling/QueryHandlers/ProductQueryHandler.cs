using Grove.Handling.Abstraction;
using Grove.Shared.Abstraction;
using Grove.Shared.Transfer.Data;
using Grove.Shared.Transfer.Queries;
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
