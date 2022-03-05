using CryptoMonitor.DAL.Entities;
using CryptoMonitor.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoMonitor.BLL.Services
{
    public class AccountService
    {
        private CryptoMonitorDbContext _db;
        private AccountRepository _accountRepository;
        public AccountService(CryptoMonitorDbContext db, AccountRepository accountRepository)
        {
            _db = db;
            _accountRepository = accountRepository;
        }

        public bool IsAccount(string login, string password)
        {
            var isAccount = _accountRepository.IsAccount(login, password);
            return isAccount;
        }

        public void UserRegistration(string login, string password, string lastName, string firstName)
        {
            var role = _db.Role.FirstOrDefault(r => r.RoleName == "Default user");

            _accountRepository.UserRegistration(login, password, lastName, firstName, role);
            _db.SaveChanges();
        }
    }
}
