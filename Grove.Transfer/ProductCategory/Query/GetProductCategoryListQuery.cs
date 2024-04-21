using Grove.Shared.Abstraction;
using Grove.Transfer.ProductCategory.Data;

namespace Grove.Transfer.ProductCategory.Query
{
    public class GetProductCategoryListQuery : ISearchQuery<ProductCategoryDto>
    {
        public int? PageIndex { get; set; }

        public int? PageSize { get; set; }

        public string? Search { get; set; }

        public string[]? Fields { get; set; }

        public string? Sort { get; set; }

        public string? Order { get; set; }
    }
}
