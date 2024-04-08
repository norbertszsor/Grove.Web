﻿using Grove.Data.Abstraction;

namespace Grove.Data.Models
{
    public class BillingItemEm : Entity<Guid>
    {
        public required Guid BillingId { get; set; }

        public virtual required BillingEm Billing { get; set; }

        public required Guid ProductId { get; set; }

        public virtual required ProductEm Product { get; set; }

        public int Quantity { get; set; }

        public decimal Value { get; set; }
    }
}
