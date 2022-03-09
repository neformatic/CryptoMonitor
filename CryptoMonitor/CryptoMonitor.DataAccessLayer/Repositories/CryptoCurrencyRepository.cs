using CryptoMonitor.DAL.Entities;
using CryptoMonitor.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoMonitor.DAL.Repositories
{
    public class CryptoCurrencyRepository : ICryptoCurrencyRepository
    {
        private readonly CryptoMonitorDbContext _db;
        public CryptoCurrencyRepository(CryptoMonitorDbContext db)
        {
            _db = db;
        }

        public List<CryptoCurrency> GetCryptoCurrencies()
        {
            var cryptoCurrencies = _db.CryptoCurrency.ToList();
            return cryptoCurrencies; 
        }
        public int GetCryptoCurrencyById(int id)
        {
            var cryptoCurrency = _db.CryptoCurrency.Where(c => c.Id == id).Select(c => c.Id).FirstOrDefault();
            
            return cryptoCurrency;
        }
        public string GetCryptoCurrencyByName(string name)
        {
            var cryptoCurrency = _db.CryptoCurrency.Where(c => c.CurrencyName == name).Select(c => c.CurrencyName).FirstOrDefault();

            return cryptoCurrency;
        }

        public void AddCryptoCurrency(string currencyName, decimal currencyPrice, DateTime updatedDate, string currencyImage)
        {
            var newCryptoCurrency = new CryptoCurrency
            {
                CurrencyName = currencyName,
                CurrencyPrice = currencyPrice,
                UpdatedDate = updatedDate,
                CurrencyImage = currencyImage
            };
            _db.CryptoCurrency.Add(newCryptoCurrency);
            _db.SaveChanges();
        }

        public void EditCryptoCurrency(int id, string currencyName, decimal currencyPrice, DateTime updatedDate, string currencyImage) ///////// уточнить
        {
            var editedCryptoCurrency = new CryptoCurrency
            {
                CurrencyName = currencyName,
                CurrencyPrice = currencyPrice,
                UpdatedDate = updatedDate,
                CurrencyImage = currencyImage
            };
            _db.CryptoCurrency.Add(editedCryptoCurrency);
            _db.SaveChanges();
        }

        public void DeleteCryptoCurrency(int id)
        {
             var cryptoCurrency = _db.CryptoCurrency.Find(id);
            _db.CryptoCurrency.Remove(cryptoCurrency);
            _db.SaveChanges();
        }
    }
}

