namespace P03_SalesDatabase.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-OSIHADJ\SQLEXPRESS;Database=Hospital;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureCustomerEntity(modelBuilder);
            ConfigureProductEntity(modelBuilder);
            ConfigureStoreEntity(modelBuilder);
            ConfigureSaleEntity(modelBuilder);
        }

        private void ConfigureSaleEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Sale>()
                .HasKey(s => s.SaleId);

            modelBuilder
                .Entity<Sale>()
                .Property(s => s.Date)
                .HasDefaultValueSql("GETDATE()");
        }

        private void ConfigureStoreEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Store>()
                .HasKey(s => s.StoreId);

            modelBuilder
                .Entity<Store>()
                .HasMany(store => store.Sales)
                .WithOne(sale => sale.Store);

            modelBuilder
                .Entity<Store>()
                .Property(s => s.Name)
                .HasMaxLength(80)
                .IsUnicode();
        }

        private void ConfigureProductEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.Sales)
                .WithOne(s => s.Product);

            modelBuilder
               .Entity<Product>()
               .Property(p => p.Name)
               .HasMaxLength(50)
               .IsUnicode();

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(250)
                .HasDefaultValue("No description");
        }

        private static void ConfigureCustomerEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder
                .Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(s => s.Customer);

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.Name)
                .HasMaxLength(80);
        }
    }
}
