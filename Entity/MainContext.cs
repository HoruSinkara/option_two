using Microsoft.EntityFrameworkCore;

using option_two.Entity.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace option_two.Entity
{
    public class MainContext:DbContext
    {
        private readonly string _connectionString = @"Data Source=192.168.221.12;Initial Catalog = option_two; User ID = user02; Password=02;TrustServerCertificate=True";
        public DbSet<Service> services { get; set; }
        public MainContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
