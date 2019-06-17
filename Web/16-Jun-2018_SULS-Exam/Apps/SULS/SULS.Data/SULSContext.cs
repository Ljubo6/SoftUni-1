namespace SULS.Data
{
    using Microsoft.EntityFrameworkCore;
    using SULS.Models;

    public class SULSContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSettings.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(user => user.Id);
            modelBuilder.Entity<User>()
                .HasMany(user => user.Submissions)
                .WithOne(submission => submission.User);

            modelBuilder.Entity<Problem>()
                .HasKey(problem => problem.Id);
            modelBuilder.Entity<Problem>()
                .HasMany(problem => problem.Submissions)
                .WithOne(submission => submission.Problem);

            modelBuilder.Entity<Submission>()
                .HasKey(submission => submission.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}