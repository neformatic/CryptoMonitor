using CryptoMonitor.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.BLL.Interfaces
{
    public interface IAccountService
    {
        AccountModel GetAccountModel(string login, string password);
        void Registration(UserModel userDataModel);
        int GetAccountId(string login);
    }
}
