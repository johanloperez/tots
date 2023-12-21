using challenge.domain.layer.Dtos;
using challenge.domain.layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge.domain.layer.Contracts
{
    public interface IEventMapper
    {
        EventDto MapToDto(Event events);
    }
}
