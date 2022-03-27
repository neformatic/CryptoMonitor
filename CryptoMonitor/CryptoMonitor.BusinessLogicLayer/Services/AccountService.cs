using AutoMapper;
using CryptoMonitor.BLL.DTO;
using CryptoMonitor.BLL.Interfaces;
using CryptoMonitor.Common;
using CryptoMonitor.DAL.DTO;
using CryptoMonitor.DAL.Interfaces;
using CryptoMonitor.DAL.Repositories;

namespace CryptoMonitor.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IUserRepository userRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public AccountModel GetAccountModel(string login, string password)
        {
            var acccountModel = _accountRepository.GetAccountModel(login, password);
            var mappedModel = _mapper.Map<AccountModel>(acccountModel);
            return mappedModel;
        }

        public void Registration(UserModel userDataModel) 
        {
            var mappedAccount = _mapper.Map<AccountDataModel>(userDataModel.Account);
            var accountId = _accountRepository.AddAccount(mappedAccount);
            var mappedUser = _mapper.Map<UserDataModel>(userDataModel);
            mappedUser.AccountId = accountId;
            _userRepository.AddUser(mappedUser);
            _accountRepository.Save();
        }

        public int GetAccountId(string login)
        {
            var AccountId = _accountRepository.GetAccountId(login);
            return AccountId;
        }
    }
}
