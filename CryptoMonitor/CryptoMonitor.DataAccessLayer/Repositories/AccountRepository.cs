using AutoMapper;
using CryptoMonitor.Common;
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
        private readonly IMapper _mapper;
        public AccountRepository(CryptoMonitorDbContext db, IMapper mapper) 
        {
            _db = db;
            _mapper = mapper;
        }
        
        public AccountDataModel GetAccountModel(string login, string password)
        {
            var userAccount = _db.Account.FirstOrDefault(a => a.AccountLogin == login && a.AccountPassword == password);
            var mappedModel = _mapper.Map<AccountDataModel>(userAccount);
            return mappedModel;
        }

        public int AddAccount(AccountDataModel accountDataModel)
        {
            Account newAccount = new Account {
                AccountLogin = accountDataModel.AccountLogin,
                AccountPassword = accountDataModel.AccountPassword,
                Role = RoleTypes.DefaultUser
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
