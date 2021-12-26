using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.ForCreationDto;
using Entities.DataTransferObjects.ForUpdateDto;
using Entities.Models;

namespace BankSistem
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<Town, TownDto>();

            CreateMap<Card, CardDto>();
            CreateMap<CardForCreationDto, Card>();
            CreateMap<CardForUpdateDto, Card>().ReverseMap();
        }
    }
}
