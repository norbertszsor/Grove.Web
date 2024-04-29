using Grove.Data;
using Grove.Data.Models;
using Grove.Infrastructure.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Grove.Infrastructure
{
    public class ReadOnlyStorage(GroveDbContext context) : IReadOnlyStorage
    {
        public IQueryable<BillingEm> Billings => context.Billings.AsNoTracking();

        public IQueryable<BillingItemEm> BillingItems => context.BillingItems.AsNoTracking();

        public IQueryable<CustomerEm> Customers => context.Customers.AsNoTracking();

        public IQueryable<ProductEm> Products => context.Products.AsNoTracking();

        public IQueryable<ProductCategoryEm> ProductCategories => context.ProductCategories.AsNoTracking();

        public IQueryable<ProductRegionEm> Regions => context.Regions.AsNoTracking();

        public IQueryable<BinaryFileEm> Files => context.Files.AsNoTracking();
    }
}
