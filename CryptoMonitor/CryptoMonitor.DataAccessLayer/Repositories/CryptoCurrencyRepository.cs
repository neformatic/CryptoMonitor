using AutoMapper;
using CryptoMonitor.DAL.DTO;
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
        private readonly IMapper _mapper;

        public CryptoCurrencyRepository(CryptoMonitorDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<CryptoCurrencyDataModel> GetCryptoCurrencies()
        {
            var cryptoCurrencies = _db.CryptoCurrency.ToList();
            var mapped = _mapper.Map<List<CryptoCurrencyDataModel>>(cryptoCurrencies);
            return mapped; 
        }
        public int GetCryptoCurrencyById(int id) // вернуть модель
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

        public void EditCryptoCurrency(CryptoCurrencyDataModel cryptoCurrencyDataModel) ///////// уточнить
        {
            var cryptoCurrency = _db.CryptoCurrency.FirstOrDefault(c => c.Id == cryptoCurrencyDataModel.Id);
            if (cryptoCurrency == null)
            {
                return;
            }
            cryptoCurrency.CurrencyName = cryptoCurrencyDataModel.CurrencyName;
            cryptoCurrency.CurrencyPrice = cryptoCurrencyDataModel.CurrencyPrice;
            cryptoCurrency.UpdatedDate = cryptoCurrencyDataModel.UpdatedDate;
            cryptoCurrency.CurrencyImage = cryptoCurrencyDataModel.CurrencyImage;
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

