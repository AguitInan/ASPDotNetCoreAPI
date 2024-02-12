using AutoMapper;
using Exercice05.DTOs;
using Exercice05.Models;

namespace Exercice05.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            // cette ligne permet de dire qu'a l'aide du mapper on pourra passer de l'entité vers le DTO
            // et vice versa grace au .ReverseMap()

            CreateMap<Ingredient, IngredientDTO>().ReverseMap();
            // cette ligne permet de dire qu'a l'aide du mapper on pourra passer de l'entité vers le DTO
            // et vice versa grace au .ReverseMap()

            CreateMap<Pizza, PizzaDTO>().ReverseMap();
            // cette ligne permet de dire qu'a l'aide du mapper on pourra passer de l'entité vers le DTO
            // et vice versa grace au .ReverseMap()

            //CreateMap<ContactDTO, ContactFullNameDTO>();
        }
    }
}
