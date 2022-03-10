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

        public void UserRegistration(string login, string password, string lastName, string firstName)
        {
            var role = _db.Role.OrderBy(r => r.Id).First(); // почитать
            Account newAccount = new Account { AccountLogin = login, AccountPassword = password, Role = role }; //навигационные свойства
            newAccount.User.FirstName = firstName;
            newAccount.User.LastName = lastName;
            _db.Account.Add(newAccount); 
            _db.SaveChanges(); // перенести в bl
        }

        public int GetAccountId(string login)
        {
            var accountId = _db.Account.Where(a => a.AccountLogin == login).Select(a => a.Id).FirstOrDefault();
            return accountId;
        }
    }
}
