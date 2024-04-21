using System.Linq.Expressions;
using Grove.Shared.Abstraction;

namespace Grove.Shared.Extensions
{
    public static class QueryableExtension
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public static IQueryable<T> Sort<T>(this IQueryable<T> query, ISortQuery<T> sortQuery)
        {
            if (sortQuery.Sort == null || sortQuery.Order == null)
            {
                return query;
            }

            var parameter = Expression.Parameter(typeof(T), "x");

            var property = Expression.Property(parameter, sortQuery.Sort);

            var lambda = Expression.Lambda(property, parameter);

            var method = sortQuery.Order == "asc" ? "OrderBy" : "OrderByDescending";

            var methodCall = Expression.Call(typeof(Queryable), method, [typeof(T), property.Type], query.Expression, lambda);

            return query.Provider.CreateQuery<T>(methodCall);
        }

        public static IQueryable<T> Search<T>(this IQueryable<T> query, ISearchQuery<T> searchQuery)
        {
            if (searchQuery.Search == null || searchQuery.Fields == null || searchQuery.Fields.Length == 0)
            {
                return query;
            }

            var search = searchQuery.Search.ToLower();

            var fields = searchQuery.Fields;

            var parameter = Expression.Parameter(typeof(T), "x");

            Expression body = Expression.Constant(false);

            foreach (var field in fields)
            {
                var property = Expression.Property(parameter, field);
                
                var toLower = Expression.Call(property, "ToLower", null);
                
                var contains = Expression.Call(toLower, "Contains", null, Expression.Constant(search));

                body = Expression.OrElse(body, contains);
            }

            var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);

            return query.Where(lambda);
        }

        public static IPagedList<T> ToPagedList<T, TResponse>(this IQueryable<T> query, IPagedQuery<TResponse> pagedQuery)
        {
            var count = query.Count();

            var items = query.Paginate(pagedQuery.PageIndex ?? 1, pagedQuery.PageSize ?? 10);

            if (pagedQuery is ISortQuery<T> sortQuery)
            {
                items = items.Sort(sortQuery);
            }

            if (pagedQuery is ISearchQuery<T> searchQuery)
            {
                items = items.Search(searchQuery);
            }

            return new PagedList<T>(items.ToList(), count, pagedQuery.PageIndex ?? 1, pagedQuery.PageSize ?? 10);
        }
    }
}
