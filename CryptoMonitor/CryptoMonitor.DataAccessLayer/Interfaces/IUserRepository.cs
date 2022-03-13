using CryptoMonitor.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.DAL.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(UserDataModel userDataModel);
        void Save();
    }
}
