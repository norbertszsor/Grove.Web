using System.Linq.Expressions;
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

        public async Task<Guid> InsertAsync<T>(T entity) where T : Entity
        {
            await context.AddAsync(entity);

            await SaveChangesAsync();

            return entity.Id;
        }

        public async Task<T> InsertEntityAsync<T>(T entity) where T : Entity
        {
            await context.AddAsync(entity);

            await SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Guid>> BulkInsertAsync<T>(IEnumerable<T>? entities) where T : Entity
        {
            if (entities == null)
            {
                return [];
            }

            entities = entities.ToList();

            await context.AddRangeAsync(entities);

            await SaveChangesAsync();

            return entities.Select(e => e.Id);
        }

        public async Task<Guid> UpdateAsync<T>(T entity) where T : Entity
        {
            context.Update(entity);

            await SaveChangesAsync();

            return entity.Id;
        }

        public async Task<T> UpdateEntityAsync<T>(T entity) where T : Entity
        {
            context.Update(entity);

            await SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync<T>(T entity) where T : Entity
        {
            context.Remove(entity);

            return await SaveChangesAsync() > 0;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public Guid Insert<T>(T entity) where T : Entity
        {
            context.Add(entity);

            SaveChanges();

            return entity.Id;
        }

        public T InsertEntity<T>(T entity) where T : Entity
        {
            context.Add(entity);

            SaveChanges();

            return entity;
        }

        public IEnumerable<Guid> BulkInsert<T>(IEnumerable<T> entities) where T : Entity
        {
            entities = entities.ToList();

            context.AddRange(entities);

            SaveChanges();

            return entities.Select(e => e.Id);
        }

        public Guid Update<T>(T entity) where T : Entity
        {
            context.Update(entity);

            SaveChanges();

            return entity.Id;
        }

        public T UpdateEntity<T>(T entity) where T : Entity
        {
            context.Update(entity);

            SaveChanges();

            return entity;
        }

        public bool Delete<T>(T entity) where T : Entity
        {
            context.Remove(entity);

            return SaveChanges() > 0;
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
