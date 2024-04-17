using Grove.Transfer.Data;

namespace Grove.Transfer.Queries
{
    public class GetProductListQuery : ISearchQuery<ProductDto>
    {
        public int? PageIndex { get; set; }

        public int? PageSize { get; set; }

        public string? Search { get; set; }

        public string[]? Fields { get; set; }
    }
}
