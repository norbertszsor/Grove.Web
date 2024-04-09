using MediatR;

namespace Grove.Shared.Abstraction
{
    public interface IQuery<out TResponse>: IRequest<TResponse>
    {
    }

    public interface IPagedQuery<out TResponse> : IQuery<IPagedList<TResponse>>
    {
        int PageIndex { get; }

        int PageSize { get; }
    }

    public interface ISearchQuery<out TResponse> : IQuery<IPagedList<TResponse>>
    {
        string Search { get; }

        string[] Fields { get; }
    }
}
