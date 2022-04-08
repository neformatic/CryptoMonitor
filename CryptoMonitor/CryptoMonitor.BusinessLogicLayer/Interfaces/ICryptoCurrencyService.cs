using CryptoMonitor.BLL.DTO;
using CryptoMonitor.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.BLL.Interfaces
{
    public interface ICryptoCurrencyService
    {
        List<CryptoCurrencyModel> GetCryptoCurrencies();
        CryptoCurrencyModel GetCryptoCurrencyById(int id);
        CryptoCurrencyModel GetCryptoCurrencyByName(string name);
        void AddCryptoCurrency(CryptoCurrencyModel cryptoCurrency);
        void EditCryptoCurrency(CryptoCurrencyModel cryptoCurrency);
        List<CryptoCurrencyModel> SearchingCurrency(string searchString);
        void DeleteCryptoCurrency(int id);
    }
}
