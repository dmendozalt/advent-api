using Advent.Final.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Final.DataAccess.Context
{
    public class SqlServerContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        private readonly string _connectionString = string.Empty;

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        public SqlServerContext() => _connectionString = @"Data Source = DESKTOP-R4U1A54\SQLEXPRESS; Initial Catalog = Advent; Integrated Security = true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
