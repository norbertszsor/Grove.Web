using Grove.Handling.Abstraction;
using Grove.Infrastructure.Abstraction;
using Grove.Shared.Abstraction;
using Grove.Shared.Enums;
using Grove.Shared.Extensions;
using Grove.Transfer.Product.Data;
using Grove.Transfer.ProductCategory.Data;
using Grove.Transfer.ProductCategory.Query;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Grove.Handling.QueryHandlers
{
    public class ProductCategoryQueryHandler(IReadOnlyStorage storage) : IQueryHandler<GetProductCategoryQuery, ProductCategoryDto>,
        ISearchQueryHandler<GetProductCategoryListQuery, ProductCategoryDto>
    {
        public async Task<ProductCategoryDto> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var product = await storage.ProductCategories.FirstOrDefaultAsync(x => x.Id == request.Id,
                cancellationToken: cancellationToken);

            return product == null ? throw GroveError.ProductNotFound.Throw() : product.Adapt<ProductCategoryDto>();
        }

        public async Task<IPagedList<ProductCategoryDto>> Handle(GetProductCategoryListQuery request,
            CancellationToken cancellationToken)
        {
            var products = storage.ProductCategories.ToPagedList(request);

            return products.Adapt<IPagedList<ProductCategoryDto>>();
        }
    }
}
