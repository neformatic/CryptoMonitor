using AutoMapper;
using CryptoMonitor.BLL.DTO;
using CryptoMonitor.BLL.Interfaces;
using CryptoMonitor.DAL.DTO;
using CryptoMonitor.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.BLL.Services
{
    public class BetService : IBetService
    {
        private readonly IMapper _mapper;
        private readonly IBetRepository _betRepository;

        public BetService(IBetRepository betRepository, IMapper mapper)
        {
            _betRepository = betRepository;
            _mapper = mapper;
        }

        public void AddUserBet(BetModel betModel)
        {
            var mappedModel = _mapper.Map<BetDataModel>(betModel);
            _betRepository.AddUserBet(mappedModel);
            _betRepository.Save();
        }

        public List<string>GetCurrencyNamesByUserId(int id)
        {
            var currencyNames = _betRepository.GetCurrencyNamesByUserId(id);
            _betRepository.Save();
            return currencyNames;
        }

    }
}
