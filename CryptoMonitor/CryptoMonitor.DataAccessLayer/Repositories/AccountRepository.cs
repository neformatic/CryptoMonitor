using CryptoMonitor.DAL.Entities;
using Microsoft.EntityFrameworkCore;
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

        public bool IsAccount(string login, string password)
        {
            var userAccount = _db.Account.Where(a => a.AccountLogin == login && a.AccountPassword == password).FirstOrDefault();
            return userAccount != null;
        }

        public void UserRegistration(string login, string password, string lastName, string firstName)
        {
            //var newUser = new User
            //{

            //};
            //_db.User.Add(newUser);

            Account newAccount = new Account { AccountLogin = login, AccountPassword = password };
            User newUser = new User { LastName = lastName, FirstName = firstName };
            _db.Account.Add(newAccount);
            _db.User.Add(newUser);
            

            //var newUser = _db.User.Include(a => a.Account).Where().ToList();
            //foreach (var user in newUser)
            //{
            //    user.Account.AccountLogin = login;
            //    user.Account.AccountPassword = password;
            //    user.LastName = lastName;
            //    user.FirstName = firstName;
            //}
        }
    }
}
