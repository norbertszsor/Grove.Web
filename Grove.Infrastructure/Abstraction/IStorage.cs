using System.Linq.Expressions;
using Grove.Data.Abstraction;
using Grove.Data.Models;

namespace Grove.Infrastructure.Abstraction
{
    public interface IStorage
    {
        IQueryable<BillingEm> Billings { get; }

        IQueryable<BillingItemEm> BillingItems { get; }

        IQueryable<CustomerEm> Customers { get; }

        IQueryable<ProductEm> Products { get; }

        IQueryable<ProductCategoryEm> ProductCategories { get; }

        Task<Guid> InsertAsync<T>(T entity) where T : Entity;

        Task<T> InsertEntityAsync<T>(T entity) where T : Entity;

        Task<IEnumerable<Guid>> BulkInsertAsync<T>(IEnumerable<T>? entities) where T : Entity;

        Task<Guid> UpdateAsync<T>(T entity) where T : Entity;

        Task<T> UpdateEntityAsync<T>(T entity) where T : Entity;

        Task<bool> DeleteAsync<T>(T entity) where T : Entity;

        Task<int> SaveChangesAsync();

        Guid Insert<T>(T entity) where T : Entity;

        T InsertEntity<T>(T entity) where T : Entity;

        IEnumerable<Guid> BulkInsert<T>(IEnumerable<T> entities) where T : Entity;

        Guid Update<T>(T entity) where T : Entity;

        T UpdateEntity<T>(T entity) where T : Entity;

        bool Delete<T>(T entity) where T : Entity;

        int SaveChanges();
    }
}
