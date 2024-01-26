using AutoMapper;
using DTOs;
using PaparaApp.API.DTOs;
using PaparaApp.API.Models.Users;

namespace Mapping;

public class DtoProfile : Profile
{

    public DtoProfile()
    {
        CreateMap<User, GetUserDto>();//.ReverseMap() de kullanabilirim;
        CreateMap<AddUserDto, User>().ReverseMap();

        CreateMap<UpdateUserDto, User>().ReverseMap();
    }

}