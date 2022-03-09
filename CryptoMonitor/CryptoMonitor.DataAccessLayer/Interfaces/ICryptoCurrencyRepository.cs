using CryptoMonitor.DAL.DTO;
using System;
using System.Collections.Generic;

namespace CryptoMonitor.DAL.Interfaces
{
    public interface ICryptoCurrencyRepository
    {
        List<CryptoCurrencyDataModel> GetCryptoCurrencies();
        int GetCryptoCurrencyById(int id);
        string GetCryptoCurrencyByName(string name);
        void AddCryptoCurrency(string currencyName, decimal currencyPrice, DateTime updatedDate, string currencyImage);
        void EditCryptoCurrency(CryptoCurrencyDataModel cryptoCurrency);
        void DeleteCryptoCurrency(int id);
    }
}
