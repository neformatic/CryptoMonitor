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
            CreateMap<RegistrationViewModel, UserModel>()
                .ForPath(u => u.Account.AccountLogin, opt => opt.MapFrom(r => r.Login))
                .ForPath(u => u.Account.AccountPassword, opt => opt.MapFrom(r => r.Password)).ReverseMap();
            CreateMap<BetViewModel, BetModel>().ReverseMap();
            CreateMap<UserBetViewModel, BetModel>().ReverseMap();
        }
    }
}
