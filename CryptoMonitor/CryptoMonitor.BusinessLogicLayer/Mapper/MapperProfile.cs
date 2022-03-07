using AutoMapper;
using CryptoMonitor.BLL.DTO;
using CryptoMonitor.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.BLL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AccountDataModel, AccountModel>().ReverseMap();
            CreateMap<CryptoCurrencyDataModel, CryptoCurrencyModel>().ReverseMap();
            CreateMap<RoleDataModel, RoleModel>().ReverseMap();
            CreateMap<UserDataModel, UserModel>().ReverseMap();
        }
    }
}
