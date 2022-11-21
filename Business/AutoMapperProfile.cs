using AutoMapper;
using Business.Models;
using Data.Entities.AccountEntity;
using Data.Entities.ContactEntity;
using Data.Entities.IncidentEntity;

namespace Business
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Incident, IncidentDto>().ReverseMap()
                .ForMember(dest => dest.Name, act => act.Ignore());
            CreateMap<Contact, IncidentDto>().ReverseMap();
        }
    }
}
