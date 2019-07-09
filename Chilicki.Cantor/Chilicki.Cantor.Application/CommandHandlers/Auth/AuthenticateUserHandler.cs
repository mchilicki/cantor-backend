using AutoMapper;
using Chilicki.Cantor.Application.Commands.Auth;
using Chilicki.Cantor.Application.Configurations.Auth;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Exceptions.Users;
using Chilicki.Cantor.Domain.Services.Users.Base;
using Chilicki.Cantor.Domain.ValueObjects.Users;
using Chilicki.Cantor.Infrastructure.Repositories.Users.Base;
using Chilicki.Cantor.Infrastructure.UnitsOfWork;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.CommandHandlers.Auth
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, UserToken>
    {
        readonly IUserRepository _userRepository;
        readonly IMapper _mapper;
        readonly IConfiguration _configuration;
        readonly IUserService _userService;
        readonly IUnitOfWork _unitOfWork;

        public AuthenticateUserHandler(
            IUserRepository userRepository,
            IMapper mapper,
            IConfiguration configuration,
            IUserService userService,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserToken> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var secretKey = GetConfigurationSecretKey();
            var userCredentials = _mapper.Map<UserCredentials>(request);
            var user = await _userRepository.FindByLoginOrEmailAndPassword(userCredentials);
            ShouldUserBeAuthenticated(user);
            var userToken = _userService.GenerateUserToken(user, secretKey);
            var authenticatedUser = _userService.UpdateUserToken(user, userToken);
            await _unitOfWork.SaveAsync();
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
            var authenticationSettingsSection = _configuration.GetSection(nameof(AuthenticationSettings));
            var authenticationSettings = authenticationSettingsSection.Get<AuthenticationSettings>();
            return authenticationSettings.Secret;
        }
    }
}
