using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Services.Auth.Base;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Chilicki.Cantor.Domain.Services.Auth
{
    public class UserTokenGenerator : IUserTokenGenerator
    {
        private readonly int EXPIRES_IN_DAYS = 7;

        public string GenerateToken(User user, string secretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();            
            var tokenDescriptor = CreateTokenDescriptor(user, secretKey);
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        private SecurityTokenDescriptor CreateTokenDescriptor(User user, string secretKey)
        {
            var byteKey = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(EXPIRES_IN_DAYS),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenDescriptor;
        }
    }
}
