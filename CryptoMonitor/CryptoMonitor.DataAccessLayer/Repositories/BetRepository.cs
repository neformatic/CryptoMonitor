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
            if (betDataModel.BetPrice == 0)
            {
                return;
            }
            var mappedModel = _mapper.Map<Bet>(betDataModel);
            //var bet = _db.Bet.FirstOrDefault(b => b.CurrencyId == mappedModel.CurrencyId & b.UserId == mappedModel.UserId & b.BetPrice != 0);
            var bet = _db.Bet.Where(b => b.CurrencyId == mappedModel.CurrencyId & b.UserId == mappedModel.UserId & b.BetPrice != 0).Include(c => c.Currency).FirstOrDefault();

            if (bet != null)
            {
                if (mappedModel.BetPrice <= bet.Currency.CurrencyPrice)
                {
                    return;
                }
                else
                {
                    bet.CurrencyId = mappedModel.CurrencyId;
                    bet.UserId = mappedModel.UserId;
                    bet.BetPrice = mappedModel.BetPrice;
                    bet.BetDate = DateTime.Now;
                    bet.IsNotified = false;
                    bet.IsWonBet = false;
                }
                
            }
            else
            {
                _db.Bet.Add(mappedModel);
            }
        }
      
        public List<string> GetCurrencyNamesByUserId(int id)
        {
            var bets = _db.Bet.Where(c => c.UserId == id && c.BetPrice <= c.Currency.CurrencyPrice && !c.IsNotified).Include(b => b.Currency).ToList();
            bets.ForEach(bets => bets.IsNotified = true);
            var currencyNames = bets.Select(b => b.Currency.CurrencyName).ToList();
            return currencyNames;
        }

        public List<BetDataModel>GetActiveBetsByCurrency(int id)
        {
            var bets = _db.Bet.Where(b => b.CurrencyId == id && b.IsWonBet == false).ToList();
            var mappedModels = _mapper.Map<List<BetDataModel>>(bets);
            return mappedModels;
        }

        public void ChangeBetStatus(int id)
        {
            var betById = _db.Bet.FirstOrDefault(b => b.Id == id);
            betById.IsWonBet = true;

        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
