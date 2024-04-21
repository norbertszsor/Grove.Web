using Grove.Handling.Abstraction;
using Grove.Infrastructure.Abstraction;
using Grove.Shared.Abstraction;
using Grove.Shared.Enums;
using Grove.Shared.Extensions;
using Grove.Transfer.Product.Data;
using Grove.Transfer.Product.Query;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Grove.Handling.QueryHandlers
{
    public class ProductQueryHandler(IReadOnlyStorage storage) : IQueryHandler<GetProductQuery, ProductDto>,
        ISearchQueryHandler<GetProductListQuery, ProductDto>
    {
        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await storage.Products.FirstOrDefaultAsync(x => x.Id == request.Id,
                    cancellationToken: cancellationToken);

            return product == null ? throw GroveError.ProductNotFound.Throw() : product.Adapt<ProductDto>();
        }

        public Task<IPagedList<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = storage.Products.ToPagedList(request);

            return Task.FromResult(products.Adapt<IPagedList<ProductDto>>());
        }
    }
}
