using Grove.Data;
using Grove.Data.Abstraction;
using Grove.Data.Models;
using Grove.Infrastructure.Abstraction;

namespace Grove.Infrastructure
{
    public class Storage(GroveDbContext context) : IStorage
    {
        public IQueryable<BillingEm> Billings => context.Billings;

        public IQueryable<BillingItemEm> BillingItems => context.BillingItems;

        public IQueryable<CustomerEm> Customers => context.Customers;

        public IQueryable<ProductEm> Products => context.Products;

        public IQueryable<ProductCategoryEm> ProductCategories => context.ProductCategories;

        public async Task<TKey> InsertAsync<T, TKey>(T entity) where T : Entity<TKey>
        {
            context.Add(entity);

            await context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<TKey> UpdateAsync<T, TKey>(T entity) where T : Entity<TKey>
        {
            context.Update(entity);

            await context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync<T, TKey>(T entity) where T : Entity<TKey>
        {
            context.Remove(entity);

            await context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public TKey Insert<T, TKey>(T entity) where T : Entity<TKey>
        {
            context.Add(entity);

            context.SaveChanges();

            return entity.Id;
        }

        public TKey Update<T, TKey>(T entity) where T : Entity<TKey>
        {
            context.Update(entity);

            context.SaveChanges();

            return entity.Id;
        }

        public void Delete<T, TKey>(T entity) where T : Entity<TKey>
        {
            context.Remove(entity);

            context.SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
