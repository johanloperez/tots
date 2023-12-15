using challenge.domain.layer.api.Dtos;
using challenge.domain.layer.api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge.domain.layer.api.Contracts
{
    public interface IUserMapper
    {
        UserDto MapToDto(User user);
    }
}
