using AutoMapper;
using Shared.DTO.Users;
using Shared.Models;

namespace Shared.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<UserCreateDTO, UserDTO>().ReverseMap();

            CreateMap<UserUpdateDTO, UserDTO>().ReverseMap();
        }
    }
}
