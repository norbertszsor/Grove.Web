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

        Task<TKey> InsertAsync<T, TKey>(T entity) where T : Entity<TKey>;

        Task<TKey> UpdateAsync<T, TKey>(T entity) where T : Entity<TKey>;

        Task DeleteAsync<T, TKey>(T entity) where T : Entity<TKey>;

        Task SaveChangesAsync();

        TKey Insert<T, TKey>(T entity) where T : Entity<TKey>;

        TKey Update<T, TKey>(T entity) where T : Entity<TKey>;

        void Delete<T, TKey>(T entity) where T : Entity<TKey>;

        void SaveChanges();
    }
}
