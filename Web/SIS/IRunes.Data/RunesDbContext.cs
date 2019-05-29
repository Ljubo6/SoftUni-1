namespace IRunes.Data
{
    using IRunes.Models;
    using Microsoft.EntityFrameworkCore;

    public class RunesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);

            modelBuilder.Entity<Track>().HasKey(e => e.Id);

            modelBuilder.Entity<Album>().HasKey(e => e.Id);

            modelBuilder.Entity<Album>().HasMany(e => e.Tracks);
        }
    }
}
