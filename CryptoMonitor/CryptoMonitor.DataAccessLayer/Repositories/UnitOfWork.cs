using CryptoMonitor.DAL.Entities;
using CryptoMonitor.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CryptoMonitorDbContext _dbContext;
        public IAccountRepository AccountRepository { get; set; }
        public ICryptoCurrencyRepository CryptoCurrencyRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        public UnitOfWork(IAccountRepository accountRepository, ICryptoCurrencyRepository cryptoCurrencyRepository, IUserRepository userRepository, CryptoMonitorDbContext dbContext)
        {
            AccountRepository = accountRepository;
            CryptoCurrencyRepository = cryptoCurrencyRepository;
            UserRepository = userRepository;
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
