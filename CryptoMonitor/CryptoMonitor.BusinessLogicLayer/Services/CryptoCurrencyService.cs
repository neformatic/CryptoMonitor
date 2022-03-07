using CryptoMonitor.BLL.Interfaces;
using CryptoMonitor.DAL.Entities;
using CryptoMonitor.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.BLL.Services
{
    public class CryptoCurrencyService : ICryptoCurrencyService
    {
        private readonly CryptoMonitorDbContext _db;
        private readonly CryptoCurrencyRepository _cryptoCurrencyRepository;
        public CryptoCurrencyService(CryptoMonitorDbContext db, CryptoCurrencyRepository cryptoCurrencyRepository)
        {
            _db = db;
            _cryptoCurrencyRepository = cryptoCurrencyRepository;
        }

        public List<CryptoCurrency> GetCryptoCurrencies()
        {
            var cryptoCurrencies = _cryptoCurrencyRepository.GetCryptoCurrencies();
            return cryptoCurrencies;
        }

        public int GetCryptoCurrencyById(int id)
        {
            var cryptoCurrency = _cryptoCurrencyRepository.GetCryptoCurrencyById(id);
            return cryptoCurrency;
        }

        public string GetCryptoCurrencyByName(string name)
        {
            var cryptoCurrency = _cryptoCurrencyRepository.GetCryptoCurrencyByName(name);
            return cryptoCurrency;
        }

        public void AddCryptoCurrency(string currencyName, decimal currencyPrice, DateTime updatedDate, string currencyImage)
        {
            _cryptoCurrencyRepository.AddCryptoCurrency(currencyName, currencyPrice, updatedDate, currencyImage);
        }

        public void EditCryptoCurrency(string currencyName, decimal currencyPrice, DateTime updatedDate, string currencyImage)
        {
            _cryptoCurrencyRepository.EditCryptoCurrency(currencyName, currencyPrice, updatedDate, currencyImage);
        }

        public void DeleteCryptoCurrency(int id)
        {
            _cryptoCurrencyRepository.DeleteCryptoCurrency(id);
        }
    }
}
