using Advent.Final.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Advent.Final.DataAccess.Context
{
    public class MySqlContext: DbContext
    {
        private readonly string _connectionString = string.Empty;
        public DbSet<User> Users { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
        public MySqlContext() => _connectionString = "server=localhost;uid=root;pwd=123456;database=advent";
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }
    }
}
