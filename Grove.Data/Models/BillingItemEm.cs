using Grove.Data.Abstraction;

namespace Grove.Data.Models
{
    public class BillingItemEm : Entity<Guid>
    {
        public int Quantity { get; set; }

        public byte DiscountPercentage { get; set; }

        public byte TaxPercentage { get; set; }

        public decimal Price { get; set; }

        public required Guid BillingId { get; set; }

        public virtual required BillingEm Billing { get; set; }

        public required Guid ProductId { get; set; }

        public virtual required ProductEm Product { get; set; }
    }
}
