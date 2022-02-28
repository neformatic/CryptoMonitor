using CryptoMonitor.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoMonitor.DAL.Repositories
{
    public class AccountRepository
    {
        private CryptoMonitorDbContext _db;
        public AccountRepository(CryptoMonitorDbContext db)
        {
            _db = db;
        }

        public void AddNewAccount(string login, string password)
        {
            var newAccount = new Account
            {
                AccountLogin = login,
                AccountPassword = password,
                RoleId = 1
            };
            _db.Account.Add(newAccount);
            
        }

        public bool IsAccount(string login, string password)
        {
            var userAccount = _db.Account.Where(a => a.AccountLogin == login && a.AccountPassword == password).FirstOrDefault();
            return userAccount != null;
        }
    }
}
