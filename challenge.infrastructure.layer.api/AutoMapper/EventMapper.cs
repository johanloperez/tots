using AutoMapper;
using challenge.domain.layer.Contracts;
using challenge.domain.layer.Dtos;
using challenge.domain.layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge.infrastructure.layer.AutoMapper
{
    public class EventMapper : IEventMapper
    {
        private readonly IMapper _mapper;

        public EventMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public EventDto MapToDto(Event events)
        {
            return _mapper.Map<EventDto>(events);
        }

    }
}
