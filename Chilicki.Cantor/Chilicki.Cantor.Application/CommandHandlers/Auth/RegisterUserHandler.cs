using AutoMapper;
using Chilicki.Cantor.Application.Commands.Auth;
using Chilicki.Cantor.Application.DTOs;
using Chilicki.Cantor.Domain.Factories.Users.Base;
using Chilicki.Cantor.Domain.Helpers.Exceptions.Users;
using Chilicki.Cantor.Domain.ValueObjects.Users;
using Chilicki.Cantor.Infrastructure.Repositories.Users.Base;
using Chilicki.Cantor.Infrastructure.UnitsOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.CommandHandlers.Auth
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserDto>
    {
        readonly IMapper mapper;
        readonly IUserRepository userRepository;
        readonly IUserFactory userFactory;
        readonly IUnitOfWork unitOfWork;

        public RegisterUserHandler(
            IMapper mapper,
            IUserRepository userRepository,
            IUserFactory userFactory,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.userFactory = userFactory;
            this.unitOfWork = unitOfWork;
        }

        public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userToRegister = mapper.Map<UserToRegister>(request);
            await CanRegisterUser(userToRegister);
            var user = userFactory.Create(userToRegister);
            var registeredUser = await userRepository.AddAsync(user);
            await unitOfWork.SaveAsync();
            return mapper.Map<UserDto>(registeredUser);
        }

        private async Task<bool> CanRegisterUser(UserToRegister userToRegister)
        {
            var doesEmailExists = await userRepository.DoesEmailAlreadyExists(userToRegister.Email);
            if (doesEmailExists)
                throw new EmailAlreadyExistsException();
            var doesLoginExists = await userRepository.DoesLoginAlreadyExists(userToRegister.Login);
            if (doesLoginExists)
                throw new LoginAlreadyExistsException();
            return true;
        }
    }
}
