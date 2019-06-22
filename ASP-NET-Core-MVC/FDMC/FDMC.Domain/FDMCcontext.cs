namespace FDMC.Domain
{
    using FDMC.Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class FDMCcontext : DbContext
    {
        public FDMCcontext(DbContextOptions<FDMCcontext> options)
            : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cat>()
                .Property(cat => cat.Name)
                .IsUnicode();

            modelBuilder.Entity<Cat>()
                .Property(cat => cat.Breed)
                .IsUnicode();
        }
    }
}
