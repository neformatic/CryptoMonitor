using AutoMapper;
using CryptoMonitor.BLL.DTO;
using CryptoMonitor.DAL.DTO;
using CryptoMonitor.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.BLL.Mapper
{
    public class MapperProfileWEB : Profile
    {
        public MapperProfileWEB()
        {
            CreateMap<CryptoCurrencyViewModel, CryptoCurrencyModel>().ReverseMap();
            CreateMap<ShortCurrencyViewModel, CryptoCurrencyModel>().ReverseMap();
            CreateMap<RegistrationViewModel, UserModel>().ReverseMap();
        }
    }
}
