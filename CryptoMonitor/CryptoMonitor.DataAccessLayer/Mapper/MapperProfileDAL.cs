using AutoMapper;
using CryptoMonitor.DAL.DTO;
using CryptoMonitor.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.DAL.Mapper
{
    public class MapperProfileDAL : Profile
    {
        public MapperProfileDAL()
        {
            CreateMap<AccountDataModel, Account>().ReverseMap();
            CreateMap<CryptoCurrencyDataModel, CryptoCurrency>().ReverseMap();
            CreateMap<UserDataModel, User>().ReverseMap();
            CreateMap<BetDataModel, Bet>().ReverseMap();
        }
    }
}
