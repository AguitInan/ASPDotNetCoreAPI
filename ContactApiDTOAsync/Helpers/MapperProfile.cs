using AutoMapper;
using ContactApiDTO.DTOs;
using ContactApiDTO.Models;

namespace ContactApiDTO.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap();
            // cette ligne permet de dire qu'a l'aide du mapper on pourra passer de l'entité vers le DTO
            // et vice versa grace au .ReverseMap()

            CreateMap<ContactDTO, ContactFullNameDTO>();
        }
    }
}
