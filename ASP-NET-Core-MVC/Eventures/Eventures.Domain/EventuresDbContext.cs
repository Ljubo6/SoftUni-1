namespace Eventures.Domain
{
    using Eventures.Domain.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class EventuresDbContext : IdentityDbContext<EventuresUser, IdentityRole, string>
    {
        public EventuresDbContext(DbContextOptions<EventuresDbContext> options) : base(options) 
        {
        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Event>()
                .HasKey(e => e.Id);

            base.OnModelCreating(builder);
        }
    }
}
