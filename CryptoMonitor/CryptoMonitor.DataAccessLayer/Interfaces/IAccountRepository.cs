using CryptoMonitor.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.DAL.Interfaces
{
    public interface IAccountRepository
    {
        bool IsAccount(string login, string password);
        void UserRegistration(string login, string password, string lastName, string firstName);
        int GetAccountId(string login);
    }
}
