using AutoMapper;

namespace latihan.api;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Users, GetUserDTO>();
        CreateMap<AddUserDTO, Users>();
    }
}
