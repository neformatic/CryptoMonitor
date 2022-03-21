using CryptoMonitor.DAL.DTO;
using CryptoMonitor.DAL.Entities;
using CryptoMonitor.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CryptoMonitor.DAL.Repositories
{
    
    public class AccountRepository : IAccountRepository
    {
        private readonly CryptoMonitorDbContext _db;
        public AccountRepository(CryptoMonitorDbContext db) 
        {
            _db = db;
        }
        
        public bool IsAccount(string login, string password)
        {
            var userAccount = _db.Account.FirstOrDefault(a => a.AccountLogin == login && a.AccountPassword == password);
            return userAccount != null;
        }

        public int AddAccount(AccountDataModel accountDataModel)
        {
            var role = _db.Role.OrderByDescending(r => r.Id).First(); // уточнить, потому что не понял
            Account newAccount = new Account {
                AccountLogin = accountDataModel.AccountLogin,
                AccountPassword = accountDataModel.AccountPassword,
                Role = role
            };
            _db.Account.Add(newAccount);
            _db.SaveChanges();
            return newAccount.Id;
        }

        public int GetAccountId(string login)
        {
            var accountId = _db.Account.Where(a => a.AccountLogin == login).Select(a => a.Id).FirstOrDefault();
            return accountId;
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
