using CryptoMonitor.DAL.Context.DbConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CryptoMonitor.DAL.Entities
{
    public class CryptoMonitorDbContext : DbContext
    {
        public CryptoMonitorDbContext(DbContextOptions<CryptoMonitorDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
        public DbSet<Account> Account { get; set; }
        public DbSet<CryptoCurrency> CryptoCurrency { get; set; }
        public DbSet<User> User { get; set; }
    }
}
