using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Factories.Users.Base;
using Chilicki.Cantor.Domain.Services.Auth.Base;
using Chilicki.Cantor.Domain.Services.Users.Base;
using Chilicki.Cantor.Domain.ValueObjects.Users;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Chilicki.Cantor.Domain.Services.Users
{
    public class UserService : IUserService
    {
        readonly IUserTokenFactory _userTokenFactory;
        readonly IUserTokenGenerator _userTokenGenerator;

        public UserService(
            IUserTokenFactory userTokenFactory,
            IUserTokenGenerator userTokenGenerator)
        {
            _userTokenFactory = userTokenFactory;
            _userTokenGenerator = userTokenGenerator;
        }

        public UserToken GenerateUserToken(User user, string secretKey)
        {
            string tokenString = _userTokenGenerator.GenerateToken(user, secretKey);
            var userToken = _userTokenFactory.Create(tokenString);
            return userToken;
        }

        public User UpdateUserToken(User user, UserToken userToken)
        {
            user.Token = userToken.Token;
            return user;
        }
    }
}
