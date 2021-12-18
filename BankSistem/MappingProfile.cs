using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace BankSistem
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<Town, TownDto>();
        }
    }
}
