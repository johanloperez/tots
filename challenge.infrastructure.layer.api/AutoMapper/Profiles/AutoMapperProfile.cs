using AutoMapper;
using challenge.domain.layer.api.Dtos;
using challenge.domain.layer.api.Entities;

namespace challenge.infrastructure.layer.api.AutoMapper.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
