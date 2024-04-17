using Grove.Shared.Abstraction;

namespace Grove.Shared
{
    public class PagedList<T> : IPagedList<T>
    {
        public int PageIndex { get; }

        public int PageSize { get; }

        public int TotalCount { get; }

        public int TotalPages { get; }

        public bool HasPreviousPage { get; }

        public bool HasNextPage { get; }

        public IEnumerable<T> Items { get; }

        public PagedList(IEnumerable<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Items = items;
            HasPreviousPage = pageIndex > 1;
            HasNextPage = pageIndex < TotalPages;
        }
    }
}
