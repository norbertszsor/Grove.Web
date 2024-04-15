using Grove.Shared.Abstraction;
using Grove.Shared.Transfer.Data;

namespace Grove.Shared.Transfer.Queries
{
    public class GetProductListQuery : ISearchQuery<ProductDto>
    {
        public int? PageIndex { get; set; }

        public int? PageSize { get; set; }

        public string? Search { get; set; }

        public string[]? Fields { get; set; }
    }
}
