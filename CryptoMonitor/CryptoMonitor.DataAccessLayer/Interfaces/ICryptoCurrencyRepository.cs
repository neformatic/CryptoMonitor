using CryptoMonitor.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.DAL.Interfaces
{
    public interface ICryptoCurrencyRepository
    {
        List<CryptoCurrency> GetCryptoCurrencies();
        int GetCryptoCurrencyById(int id);
        string GetCryptoCurrencyByName(string name);
        void AddCryptoCurrency(string currencyName, decimal currencyPrice, DateTime updatedDate, string currencyImage);
        void EditCryptoCurrency(string currencyName, decimal currencyPrice, DateTime updatedDate, string currencyImage);
        void DeleteCryptoCurrency(int id);
    }
}
