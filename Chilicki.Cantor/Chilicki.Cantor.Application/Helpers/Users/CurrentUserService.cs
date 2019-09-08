using Chilicki.Cantor.Application.Helpers.Users.Base;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Repositories.Users.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.Helpers.Users
{
    public class CurrentUserService : ICurrentUserService
    {
        readonly IHttpContextAccessor httpContextAccessor;
        readonly IUserRepository userRepository;

        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userRepository = userRepository;
        }

        public async Task<User> GetCurrentUserAsync()
        {
            return await userRepository.FindAsync(GetUserName());
        }
               
        public User GetCurrentUser()
        {
            return userRepository.Find(GetUserName());
        }

        private Guid GetUserName()
        {
            return Guid.Parse(httpContextAccessor.HttpContext.User.Identity.Name);
        }
    }
}
