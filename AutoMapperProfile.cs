using AutoMapper;
using HRSystem.Dtos.Declaratie;
using HRSystem.Dtos.User;
using HRSystem.Dtos.Vakantie;

namespace HRSystem
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            CreateMap<Vakantie, GetVakantieDto>();
            CreateMap<AddVakantieDto, Vakantie>();
            CreateMap<UpdateDeclaratieDto, Vakantie>();

            CreateMap<Declaratie, GetDeclaratieDto>();
            CreateMap<AddDeclaratieDto, Declaratie>();
            CreateMap<UpdateDeclaratieDto, Declaratie>();
        }
    }
}
