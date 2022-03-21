using CryptoMonitor.DAL.DTO;
using System;
using System.Collections.Generic;

namespace CryptoMonitor.DAL.Interfaces
{
    public interface ICryptoCurrencyRepository
    {
        List<CryptoCurrencyDataModel> GetCryptoCurrencies();
        CryptoCurrencyDataModel GetCryptoCurrencyById(int id);
        CryptoCurrencyDataModel GetCryptoCurrencyByName(string name);
        void AddCryptoCurrency(CryptoCurrencyDataModel cryptoCurrency);
        void EditCryptoCurrency(CryptoCurrencyDataModel cryptoCurrency);
        void DeleteCryptoCurrency(int id);
        List<CryptoCurrencyDataModel> searchingCurrency(string searchString);
        void Save();
    }
}
