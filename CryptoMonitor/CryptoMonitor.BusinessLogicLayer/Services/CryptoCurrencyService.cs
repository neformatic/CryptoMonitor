using AutoMapper;
using CryptoMonitor.BLL.DTO;
using CryptoMonitor.BLL.Interfaces;
using CryptoMonitor.DAL.DTO;
using CryptoMonitor.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var mappedModels = _mapper.Map<List<CryptoCurrencyModel>>(cryptoCurrencies);
            foreach (var model in mappedModels)
            {
                model.BetModel = _mapper.Map<BetModel>(cryptoCurrencies.FirstOrDefault(c => c.Id == model.Id).BetDataModel);
            }
            return mappedModels;
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

        public List<CryptoCurrencyModel> SearchingCurrency(string searchString)
        {
            var currency = _cryptoCurrencyRepository.searchingCurrency(searchString);
            var mappedModel = _mapper.Map<List<CryptoCurrencyModel>>(currency);
            return mappedModel;
        }
    }
}
