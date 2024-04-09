namespace Grove.Shared.Abstraction
{
    public interface IPagedList<out T>
    {
        int PageIndex { get; }

        int PageSize { get; }

        int TotalCount { get; }

        int TotalPages { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }

        IEnumerable<T> Items { get; }
    }
}
