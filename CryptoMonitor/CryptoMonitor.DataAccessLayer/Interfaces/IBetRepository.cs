using CryptoMonitor.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.DAL.Interfaces
{
    public interface IBetRepository
    {
        void AddUserBet(BetDataModel betDataModel);
        List<string> GetCurrencyNamesByUserId(int id);
        List<BetDataModel> GetActiveBetsByCurrency(int id);
        void ChangeBetStatus(int id);
        void Save();
    }
}
