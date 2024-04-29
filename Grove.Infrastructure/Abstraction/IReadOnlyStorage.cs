using Grove.Data.Models;

namespace Grove.Infrastructure.Abstraction
{
    public interface IReadOnlyStorage
    {
        IQueryable<BillingEm> Billings { get; }

        IQueryable<BillingItemEm> BillingItems { get; }

        IQueryable<CustomerEm> Customers { get; }

        IQueryable<ProductEm> Products { get; }

        IQueryable<ProductCategoryEm> ProductCategories { get; }

        IQueryable<ProductRegionEm> Regions { get; }

        IQueryable<BinaryFileEm> Files { get; }
    }
}
