using CryptoMonitor.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.BLL.Interfaces
{
    public interface IAccountService
    {
        bool IsAccount(string login, string password);
        void Registration(UserModel userDataModel);
        int GetAccountId(string login);
    }
}
