using Grove.Shared.Abstraction;
using Grove.Transfer.Product.Data;

namespace Grove.Transfer.ProductCategory.Query
{
    public class GetProductQuery : IQuery<ProductDto>
    {
        public Guid Id { get; set; }
    }
}
