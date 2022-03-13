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

        public CryptoCurrencyModel GetCryptoCurrencyById(int id)
        {
            var cryptoCurrency = _cryptoCurrencyRepository.GetCryptoCurrencyById(id);
            var mapped = _mapper.Map<CryptoCurrencyModel>(cryptoCurrency);
            return mapped;
        }

        public CryptoCurrencyModel GetCryptoCurrencyByName(string name)
        {
            var cryptoCurrency = _cryptoCurrencyRepository.GetCryptoCurrencyByName(name);
            var mapped = _mapper.Map<CryptoCurrencyModel>(cryptoCurrency);
            return mapped;
        }

        public void AddCryptoCurrency(CryptoCurrencyModel cryptoCurrency)
        {
            var mapped = _mapper.Map<CryptoCurrencyDataModel>(cryptoCurrency);
            _cryptoCurrencyRepository.AddCryptoCurrency(mapped);
            _cryptoCurrencyRepository.Save();
        }

        public void EditCryptoCurrency(CryptoCurrencyModel cryptoCurrency)
        {
            var mapped = _mapper.Map<CryptoCurrencyDataModel>(cryptoCurrency);
            _cryptoCurrencyRepository.EditCryptoCurrency(mapped);
            _cryptoCurrencyRepository.Save();
        }

        public void DeleteCryptoCurrency(int id)
        {
            _cryptoCurrencyRepository.DeleteCryptoCurrency(id);
            _cryptoCurrencyRepository.Save();
        }
    }
}
