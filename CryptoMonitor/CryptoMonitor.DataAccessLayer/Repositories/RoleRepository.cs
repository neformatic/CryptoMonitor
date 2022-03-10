using CryptoMonitor.DAL.Entities;
using CryptoMonitor.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CryptoMonitor.DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CryptoMonitorDbContext _db;

        public RoleRepository(CryptoMonitorDbContext db)
        {
            _db = db;
        }

        public string GetRole(int id)
        {
            var role = (from a in _db.Account
                        join r in _db.Role on a.RoleId equals r.Id
                        where a.Id == id
                        select r.RoleName).SingleOrDefault();
            return role;
        }
    }
}
