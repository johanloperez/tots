using AutoMapper;
using challenge.domain.layer.Dtos;
using challenge.domain.layer.Entities;

namespace challenge.infrastructure.layer.AutoMapper.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Event, EventDto>();
            CreateMap<ResponseStatus, ResponseStatusDto>();
            CreateMap<Body, BodyDto>();
            CreateMap<MeetingDateTime, MeetingDateTimeDto>();
            CreateMap<Organizer, OrganizerDto>();
            CreateMap<EmailAddress, EmailAddressDto>();
        }
    }
}
