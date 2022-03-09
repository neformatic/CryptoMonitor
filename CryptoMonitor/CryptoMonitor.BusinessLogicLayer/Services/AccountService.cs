using AutoMapper;
using CryptoMonitor.BLL.Interfaces;
using CryptoMonitor.DAL.Interfaces;
using CryptoMonitor.DAL.Repositories;

namespace CryptoMonitor.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public bool IsAccount(string login, string password)
        {
            var isAccount = _accountRepository.IsAccount(login, password);
            return isAccount;
        }

        public void UserRegistration(string login, string password, string lastName, string firstName) // переделать
        {

            _accountRepository.UserRegistration(login, password, lastName, firstName);
        }

        public string GetRole(int id)
        {
            var role = _accountRepository.GetRole(id);
            return role;
        }

        public int GetAccountId(string login)
        {
            var AccountId = _accountRepository.GetAccountId(login);
            return AccountId;
        }
    }
}
