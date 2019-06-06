namespace Musaca.Data
{
    using Microsoft.EntityFrameworkCore;
    using Musaca.Models;

    public class MusacaDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(user => user.Id);

            modelBuilder.Entity<Product>()
                .HasKey(product => product.Id);

            modelBuilder.Entity<Order>()
                .HasKey(order => order.Id);

            modelBuilder.Entity<Receipt>()
                .HasKey(receipt => receipt.Id);

            modelBuilder.Entity<Receipt>()
                .HasMany(receipt => receipt.Orders);

            base.OnModelCreating(modelBuilder);
        }
    }
}
