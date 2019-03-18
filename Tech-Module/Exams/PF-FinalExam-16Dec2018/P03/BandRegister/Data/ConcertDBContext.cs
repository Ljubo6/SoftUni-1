using BandRegister.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandRegister.Data
{
    public class ConcertDBContext : DbContext
    {
        public DbSet<Band> Concerts { get; set; }

        private const string ConnectionString = @"Server=.\SQLEXPRESS; DataBase=ConcertDb; Integrated Security=true;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
