using Microsoft.EntityFrameworkCore;

namespace CryptoMonitor.DAL.Entities
{
    public class CryptoMonitorDbContext : DbContext
    {
        public CryptoMonitorDbContext(DbContextOptions<CryptoMonitorDbContext> options) : base(options)
        {

        }
        public DbSet<Account> Account { get; set; }
        public DbSet<CryptoCurrency> CryptoCurrency { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
    }
}
