using AutoMapper;
using CryptoMonitor.BLL.Interfaces;
using CryptoMonitor.DAL.Repositories;

namespace CryptoMonitor.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly AccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(AccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public bool IsAccount(string login, string password)
        {
            var isAccount = _accountRepository.IsAccount(login, password);
            return isAccount;
        }

        public void UserRegistration(string login, string password, string lastName, string firstName)
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
