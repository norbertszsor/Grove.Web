using Grove.Shared.Abstraction;
using Grove.Transfer.ProductCategory.Data;

namespace Grove.Transfer.ProductCategory.Query
{
    public class GetProductCategoryQuery : IQuery<ProductCategoryDto>
    {
        public Guid Id { get; set; }
    }
}
