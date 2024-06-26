﻿using Grove.Shared.Abstraction;
using MediatR;

namespace Grove.Handling.Abstraction
{
    public interface IQueryHandler<in TRequest> : IRequestHandler<TRequest> where TRequest : IQuery
    {
    }

    public interface IQueryHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IQuery<TResponse>
    {
    }

    public interface IPagedQueryHandler<in TRequest, TResponse> : IQueryHandler<TRequest, IPagedList<TResponse>>
        where TRequest : IPagedQuery<TResponse>
    {
    }

    public interface ISortQueryHandler<in TRequest, TResponse> : IQueryHandler<TRequest, IPagedList<TResponse>>
        where TRequest : ISortQuery<TResponse>
    {
    }

    public interface ISearchQueryHandler<in TRequest, TResponse> : ISortQueryHandler<TRequest, TResponse>
        where TRequest : ISearchQuery<TResponse>
    {
    }
}
