using AutoMapper;
using CryptoMonitor.DAL.DTO;
using CryptoMonitor.DAL.Entities;
using CryptoMonitor.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.DAL.Repositories
{
    public class BetRepository : IBetRepository
    {
        private readonly CryptoMonitorDbContext _db;
        private readonly IMapper _mapper;
        public BetRepository(CryptoMonitorDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void AddUserBet(CryptoCurrencyDataModel cryptoCurrencyDataModel)
        {
            var mappedModel = _mapper.Map<CryptoCurrency>(cryptoCurrencyDataModel);
            _db.CryptoCurrency.Add(mappedModel);
            _db.SaveChanges();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
