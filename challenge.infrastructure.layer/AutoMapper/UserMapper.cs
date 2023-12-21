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
