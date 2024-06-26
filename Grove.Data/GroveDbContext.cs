﻿using Grove.Data.Abstraction;
using Grove.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Grove.Data
{
    public class GroveDbContext(DbContextOptions<GroveDbContext> options) : DbContext(options)
    {
        public required DbSet<BillingEm> Billings { get; set; }

        public required DbSet<BillingItemEm> BillingItems { get; set; }

        public required DbSet<CustomerEm> Customers { get; set; }

        public required DbSet<ProductEm> Products { get; set; }

        public required DbSet<ProductCategoryEm> ProductCategories { get; set; }

        public required DbSet<ProductRegionEm> Regions { get; set; }

        public required DbSet<BinaryFileEm> Files { get; set; }

        public required DbSet<UserEm> Users { get; set; }

        public override int SaveChanges()
        {
            OnChanges();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillingEm>(entity =>
            {
                entity.HasMany(e => e.Items)
                    .WithOne(e => e.Billing)
                    .HasForeignKey(e => e.BillingId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<BillingItemEm>(entity =>
            {
                entity.HasOne(e => e.Billing)
                    .WithMany(e => e.Items)
                    .HasForeignKey(e => e.BillingId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Product)
                    .WithMany()
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ProductEm>(entity =>
            {
                entity.HasOne(e => e.Image)
                    .WithMany()
                    .HasForeignKey(e => e.ImageId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.Category)
                    .WithMany(e => e.Products)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Region)
                    .WithMany(e => e.Products)
                    .HasForeignKey(e => e.RegionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ProductCategoryEm>(entity =>
            {
                entity.HasMany(e => e.Products)
                    .WithOne(e => e.Category)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CustomerEm>(entity =>
            {
                entity.HasOne(e => e.Billing)
                    .WithOne(e => e.Customer)
                    .HasForeignKey<CustomerEm>(e => e.BillingId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ProductRegionEm>(entity =>
            {
                entity.HasMany(e => e.Products)
                    .WithOne(e => e.Region)
                    .HasForeignKey(e => e.RegionId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Image)
                    .WithMany()
                    .HasForeignKey(e => e.ImageId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<BinaryFileEm>(entity => { });

            modelBuilder.Entity<UserEm>(entity => { });
        }

        private void OnChanges()
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.State is EntityState.Added or EntityState.Modified);

            foreach (var entity in entities)
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.CurrentValues[nameof(Entity.CreatedAt)] = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entity.CurrentValues[nameof(Entity.UpdatedAt)] = DateTime.Now;
                        break;
                }
            }
        }
    }
}
