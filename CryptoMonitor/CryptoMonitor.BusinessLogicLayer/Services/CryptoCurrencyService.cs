using AutoMapper;
using CryptoMonitor.BLL.DTO;
using CryptoMonitor.BLL.Interfaces;
using CryptoMonitor.BLL.Models;
using CryptoMonitor.DAL.DTO;
using CryptoMonitor.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CryptoMonitor.BLL.Services
{
    public class CryptoCurrencyService : ICryptoCurrencyService
    {
        private readonly IMapper _mapper;
        private readonly ICryptoCurrencyRepository _cryptoCurrencyRepository;
        public CryptoCurrencyService(IMapper mapper, ICryptoCurrencyRepository cryptoCurrencyRepository)
        {
            _mapper = mapper;
            _cryptoCurrencyRepository = cryptoCurrencyRepository;
        }

        public List<CryptoCurrencyModel> GetCryptoCurrencies()
        {
            var cryptoCurrencies = _cryptoCurrencyRepository.GetCryptoCurrencies();
            List<CryptoCurrencyModel> cryptoCurrencyModels = new List<CryptoCurrencyModel>();
            foreach (var item in cryptoCurrencies)
            {
                var mapped = _mapper.Map<CryptoCurrencyModel>(item);
                cryptoCurrencyModels.Add(mapped);
            }
            return cryptoCurrencyModels;
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
            _cryptoCurrencyRepository.AddCryptoCurrency(currencyName, currencyPrice, updatedDate, currencyImage); // переделать
        }

        public void EditCryptoCurrency(CryptoCurrencyModel cryptoCurrency)
        {
            var mapped = _mapper.Map<CryptoCurrencyDataModel>(cryptoCurrency); // посмотреть еще раз
            _cryptoCurrencyRepository.EditCryptoCurrency(mapped);
        }

        public void DeleteCryptoCurrency(int id)
        {
            _cryptoCurrencyRepository.DeleteCryptoCurrency(id);
        }
    }
}
