using CryptoMonitor.DAL.Entities;
using CryptoMonitor.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoMonitor.DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly CryptoMonitorDbContext _db;
        private Role role = new Role() { RoleName = "Default user" };
        public AccountRepository(CryptoMonitorDbContext db)
        {
            _db = db;
        }

        public bool IsAccount(string login, string password)
        {
            var userAccount = _db.Account.Where(a => a.AccountLogin == login && a.AccountPassword == password).FirstOrDefault();
            return userAccount != null;
        }

        public void UserRegistration(string login, string password, string lastName, string firstName)
        {
            Account newAccount = new Account { AccountLogin = login, AccountPassword = password, Role = role };
            _db.Account.Add(newAccount);
            _db.SaveChanges();
            User newUser = new User { LastName = lastName, FirstName = firstName, Account = newAccount };
            _db.User.Add(newUser);
            _db.SaveChanges();
        }

        public string GetRole(int id)
        {
            var role = (from a in _db.Account
                        join r in _db.Role on a.RoleId equals r.Id
                        where a.Id == id
                        select r.RoleName).SingleOrDefault();
            return role;
        }

        public int GetAccountId(string login)
        {
            var accountId = _db.Account.Where(a => a.AccountLogin == login).Select(a => a.Id).FirstOrDefault();
            return accountId;
        }
    }
}
