using AutoMapper;
using Chilicki.Cantor.Application.Commands.Auth;
using Chilicki.Cantor.Application.Configurations.Auth;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Helpers.Exceptions.Users;
using Chilicki.Cantor.Domain.Services.Users.Base;
using Chilicki.Cantor.Domain.ValueObjects.Users;
using Chilicki.Cantor.Infrastructure.Repositories.Users.Base;
using Chilicki.Cantor.Infrastructure.UnitsOfWork;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.CommandHandlers.Auth
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, UserToken>
    {
        readonly IUserRepository userRepository;
        readonly IMapper mapper;
        readonly IConfiguration configuration;
        readonly IUserService userService;
        readonly IUnitOfWork unitOfWork;

        public AuthenticateUserHandler(
            IUserRepository userRepository,
            IMapper mapper,
            IConfiguration configuration,
            IUserService userService,
            IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.configuration = configuration;
            this.userService = userService;
            this.unitOfWork = unitOfWork;
        }

        public async Task<UserToken> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var secretKey = GetConfigurationSecretKey();
            var userCredentials = mapper.Map<UserCredentials>(request);
            var user = await userRepository.FindByLoginOrEmailAndPassword(userCredentials);
            ShouldUserBeAuthenticated(user);
            var userToken = userService.GenerateUserToken(user, secretKey);
            var authenticatedUser = userService.UpdateUserToken(user, userToken);
            await unitOfWork.SaveAsync();
            return userToken;
        }

        private bool ShouldUserBeAuthenticated(User user)
        {
            if (user == null)
                throw new UserNotAuthenticatedException();
            return true;
        }

        private string GetConfigurationSecretKey()
        {
            var authenticationSettingsSection = configuration.GetSection(nameof(AuthenticationSettings));
            var authenticationSettings = authenticationSettingsSection.Get<AuthenticationSettings>();
            return authenticationSettings.Secret;
        }
    }
}
