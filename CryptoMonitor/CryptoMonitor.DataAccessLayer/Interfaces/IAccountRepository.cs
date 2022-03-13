using CryptoMonitor.DAL.DTO;

namespace CryptoMonitor.DAL.Interfaces
{
    public interface IAccountRepository
    {
        bool IsAccount(string login, string password);
        int AddAccount(AccountDataModel accountDataModel);
        int GetAccountId(string login);
        void Save();
    }
}
