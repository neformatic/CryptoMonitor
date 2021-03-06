using AutoMapper;
using CryptoMonitor.DAL.DTO;
using CryptoMonitor.DAL.Entities;
using CryptoMonitor.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            var cryptoCurrencies = _db.CryptoCurrency.Include(b => b.Bet).ToList();
            var mappedModels = _mapper.Map<List<CryptoCurrencyDataModel>>(cryptoCurrencies);
            foreach(var model in mappedModels)
            {
                model.BetDataModel = _mapper.Map<BetDataModel>(cryptoCurrencies.FirstOrDefault(c => c.Id == model.Id).Bet);
            }
            return mappedModels; 
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
                UpdatedDate = DateTime.Now,
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
            cryptoCurrency.UpdatedDate = DateTime.Now;
            cryptoCurrency.CurrencyImage = cryptoCurrencyDataModel.CurrencyImage;
        }

        public void DeleteCryptoCurrency(int id)
        {
            var deletedCurrency = _db.CryptoCurrency.Find(id);
            _db.CryptoCurrency.Remove(deletedCurrency);
        }

        public List<CryptoCurrencyDataModel> searchingCurrency(string searchString)
        {
            var currency = _db.CryptoCurrency.Where(c => c.CurrencyName.Contains(searchString)).ToList();
            var mappedModel = _mapper.Map<List<CryptoCurrencyDataModel>>(currency);
            return mappedModel;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

