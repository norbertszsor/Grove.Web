using Grove.Shared.Abstraction;

namespace Grove.Shared
{
    public class SearchQuery<T> : ISearchQuery<T>
    {
        public int? PageIndex { get; set; }

        public int? PageSize { get; set; }

        public string? Search { get; set; }

        public string[]? Fields { get; set; }

        public string? Sort { get; set; }

        public string? Order { get; set; }
    }
}
