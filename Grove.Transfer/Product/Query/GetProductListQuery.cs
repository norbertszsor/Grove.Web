using Grove.Shared.Abstraction;
using Grove.Transfer.Product.Data;

namespace Grove.Transfer.Product.Query
{
    public class GetProductListQuery : ISearchQuery<ProductDto>
    {
        public int? PageIndex { get; set; }

        public int? PageSize { get; set; }

        public string? Search { get; set; }

        public string[]? Fields { get; set; }
    }
}
