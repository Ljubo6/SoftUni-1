namespace CatShop.Models
{
    using Microsoft.EntityFrameworkCore;

    public class CatDbContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }

        public CatDbContext()
        {
            this.Database.EnsureCreated();
        }

        private const string ConnectionString =
            @"Server=.\SQLEXPRESS; DataBase=classnameDb;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConnectionString);
        }
    }
}
