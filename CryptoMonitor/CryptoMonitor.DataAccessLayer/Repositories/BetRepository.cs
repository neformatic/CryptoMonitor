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
    public class BetRepository : IBetRepository
    {
        private readonly CryptoMonitorDbContext _db;
        private readonly IMapper _mapper;
        public BetRepository(CryptoMonitorDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void AddUserBet(BetDataModel betDataModel)
        {
            var mappedModel = _mapper.Map<Bet>(betDataModel);
            var bet = _db.Bet.FirstOrDefault(b => b.CurrencyId == mappedModel.CurrencyId & b.UserId == mappedModel.UserId & b.BetPrice != 0);
            if (bet != null)
            {
                bet.CurrencyId = mappedModel.CurrencyId;
                bet.UserId = mappedModel.UserId;
                bet.BetPrice = mappedModel.BetPrice;
                bet.BetDate = DateTime.Now;
                _db.SaveChanges();
            }
            else
            {
                _db.Bet.Add(mappedModel);
                _db.SaveChanges();
            }
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
