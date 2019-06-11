namespace Panda.Data
{
    using Microsoft.EntityFrameworkCore;
    using Panda.Models;

    public class PandaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(user => user.Id);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Packages)
                .WithOne(p => p.Recipient)
                .HasForeignKey(r => r.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Receipts)
                .WithOne(r => r.Recipient)
                .HasForeignKey(r => r.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Package>()
                .HasKey(package => package.Id);

            modelBuilder.Entity<Receipt>()
                .HasKey(receipt => receipt.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
