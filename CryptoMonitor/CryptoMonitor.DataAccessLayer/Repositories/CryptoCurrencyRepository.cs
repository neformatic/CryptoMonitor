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
            var mappedModel = new List<CryptoCurrencyDataModel>();
            foreach (var currency in cryptoCurrencies)
            {
                mappedModel.Add(_mapper.Map<CryptoCurrencyDataModel>(currency));
            }
            return mappedModel; 
        }
        public CryptoCurrencyDataModel GetCryptoCurrencyById(int id)
        {
            CryptoCurrency cryptoCurrency = _db.CryptoCurrency.Where(c => c.Id == id).FirstOrDefault();
            if (cryptoCurrency == null)
            {
                return null;
            }
            var mapped = _mapper.Map<CryptoCurrencyDataModel>(cryptoCurrency);
            return mapped;
        }
        public CryptoCurrencyDataModel GetCryptoCurrencyByName(string name)
        {
            CryptoCurrency cryptoCurrency = _db.CryptoCurrency.Where(c => c.CurrencyName == name).FirstOrDefault();
            if (cryptoCurrency == null)
            {
                return null;
            }
            var mapped = _mapper.Map<CryptoCurrencyDataModel>(cryptoCurrency);
            return mapped;
        }

        public void AddCryptoCurrency(CryptoCurrencyDataModel cryptoCurrencyDataModel)
        {
            var newCryptoCurrency = new CryptoCurrency
            {
                CurrencyName = cryptoCurrencyDataModel.CurrencyName,
                CurrencyPrice = cryptoCurrencyDataModel.CurrencyPrice,
                UpdatedDate = cryptoCurrencyDataModel.UpdatedDate,
                CurrencyImage = cryptoCurrencyDataModel.CurrencyImage
            };
            _db.CryptoCurrency.Add(newCryptoCurrency);
        }

        public void EditCryptoCurrency(CryptoCurrencyDataModel cryptoCurrencyDataModel)
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
        }

        public void DeleteCryptoCurrency(int id)
        {
            var deletedCurrency = _db.CryptoCurrency.Find(id);
            _db.CryptoCurrency.Remove(deletedCurrency);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

