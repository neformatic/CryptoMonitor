using AutoMapper;
using CryptoMonitor.BLL.DTO;
using CryptoMonitor.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.BLL.Mapper
{
    public class MapperProfileBLL : Profile
    {
        public MapperProfileBLL()
        {
            CreateMap<AccountDataModel, AccountModel>().ReverseMap();
            CreateMap<CryptoCurrencyDataModel, CryptoCurrencyModel>().ReverseMap();
            CreateMap<UserDataModel, UserModel>().ReverseMap();
            CreateMap<BetDataModel, BetModel>().ReverseMap();
        }
    }
}
