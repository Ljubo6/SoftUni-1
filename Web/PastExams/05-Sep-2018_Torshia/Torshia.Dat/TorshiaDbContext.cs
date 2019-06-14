namespace Torshia.Data
{
    using Microsoft.EntityFrameworkCore;
    using Torshia.Models;

    public class TorshiaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<UserTask> UsersTasks { get; set; }
        public DbSet<TaskSector> TasksSectors { get; set; }

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
                .HasMany(user => user.Reports)
                .WithOne(r => r.Reporter)
                .HasForeignKey(r => r.ReporterId);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tasks)
                .WithOne(tu => tu.User)
                .HasForeignKey(tu => tu.UserId);

            modelBuilder.Entity<Task>()
                .HasKey(task => task.Id);
            modelBuilder.Entity<Task>()
                .HasMany(task => task.Participants)
                .WithOne(tu => tu.Task)
                .HasForeignKey(tu => tu.TaskId);

            modelBuilder.Entity<Report>()
                .HasKey(report => report.Id);

            modelBuilder.Entity<UserTask>()
                .HasKey(ut => new { ut.TaskId, ut.UserId });
            //modelBuilder.Entity<UserTask>()
            //    .HasOne(ut => ut.Task)
            //    .WithMany(t => t.Participants)
            //    .HasForeignKey(ut => ut.TaskId);
            //modelBuilder.Entity<UserTask>()
            //   .HasOne(ut => ut.User)
            //   .WithMany(t => t.Tasks)
            //   .HasForeignKey(ut => ut.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
