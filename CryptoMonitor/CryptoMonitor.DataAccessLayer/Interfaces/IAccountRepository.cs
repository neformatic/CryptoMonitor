using CryptoMonitor.DAL.DTO;

namespace CryptoMonitor.DAL.Interfaces
{
    public interface IAccountRepository
    {
        AccountDataModel GetAccountModel(string login, string password);
        int AddAccount(AccountDataModel accountDataModel);
        int GetAccountId(string login);
        void Save();
    }
}
