using CryptoMonitor.DAL.Entities;
using CryptoMonitor.DAL.Repositories;
using System;
using System.Collections.Generic;
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

        public void AddNewAccount(string login, string password)
        {
            _accountRepository.AddNewAccount(login, password);
            _db.SaveChanges();
        }

        public bool IsAccount(string login, string password)
        {
            var isAccount = _accountRepository.IsAccount(login, password);
            return isAccount;
        }
    }
}
