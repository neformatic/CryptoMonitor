using CryptoMonitor.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMonitor.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; set; }
        ICryptoCurrencyRepository CryptoCurrencyRepository { get; set; }
        IRoleRepository RoleRepository { get; set; }
        IUserRepository UserRepository { get; set; }

        void Save();
    }
}
