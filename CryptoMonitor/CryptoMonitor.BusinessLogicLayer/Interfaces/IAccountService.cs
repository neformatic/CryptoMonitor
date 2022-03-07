﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.BLL.Interfaces
{
    public interface IAccountService
    {
        bool IsAccount(string login, string password);
        void UserRegistration(string login, string password, string lastName, string firstName);
        string GetRole(int id);
        int GetAccountId(string login);
    }
}
