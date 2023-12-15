using AutoMapper;
using challenge.domain.layer.api.Contracts;
using challenge.domain.layer.api.Dtos;
using challenge.domain.layer.api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge.infrastructure.layer.api.AutoMapper
{
    public class UserMapper : IUserMapper
    {
        private readonly IMapper _mapper;

        public UserMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserDto MapToDto(User user)
        {
            return _mapper.Map<UserDto>(user);
        }

    }
}
