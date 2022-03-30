using CryptoMonitor.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.BLL.Interfaces
{
    public interface IBetService
    {
        void AddUserBet(CryptoCurrencyModel betModel);
    }
}
