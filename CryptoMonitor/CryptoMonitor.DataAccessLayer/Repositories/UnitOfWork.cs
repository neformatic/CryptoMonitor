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
        public IRoleRepository RoleRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        public UnitOfWork(IAccountRepository accountRepository, ICryptoCurrencyRepository cryptoCurrencyRepository, IRoleRepository roleRepository, IUserRepository userRepository, CryptoMonitorDbContext dbContext)
        {
            AccountRepository = accountRepository;
            CryptoCurrencyRepository = cryptoCurrencyRepository;
            RoleRepository = roleRepository;
            UserRepository = userRepository;
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
