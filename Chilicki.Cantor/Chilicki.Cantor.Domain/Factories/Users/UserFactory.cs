﻿using AutoMapper;
using Chilicki.Cantor.Domain.Aggregates.Users;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Factories.Users.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilicki.Cantor.Domain.Factories.Users
{
    public class UserFactory : IUserFactory
    {
        readonly IMapper _mapper;

        public UserFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public User Create(UserToRegister userToRegister)
        {
            var user = _mapper.Map<User>(userToRegister);
            return user;
        }
    }
}
