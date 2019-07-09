using AutoMapper;
using Chilicki.Cantor.Application.Commands.Auth;
using Chilicki.Cantor.Application.DTOs;
using Chilicki.Cantor.Domain.Exceptions.Users;
using Chilicki.Cantor.Domain.Factories.Users.Base;
using Chilicki.Cantor.Domain.ValueObjects.Users;
using Chilicki.Cantor.Infrastructure.Repositories.Users.Base;
using Chilicki.Cantor.Infrastructure.UnitsOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.CommandHandlers.Auth
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserDTO>
    {
        readonly IMapper _mapper;
        readonly IUserRepository _userRepository;
        readonly IUserFactory _userFactory;
        readonly IUnitOfWork _unitOfWork;

        public RegisterUserHandler(
            IMapper mapper,
            IUserRepository userRepository,
            IUserFactory userFactory,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userFactory = userFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDTO> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userToRegister = _mapper.Map<UserToRegister>(request);
            await CanRegisterUser(userToRegister);
            var user = _userFactory.Create(userToRegister);
            var registeredUser = await _userRepository.AddAsync(user);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<UserDTO>(registeredUser);
        }

        private async Task<bool> CanRegisterUser(UserToRegister userToRegister)
        {
            var doesEmailExists = await _userRepository.DoesEmailAlreadyExists(userToRegister.Email);
            if (doesEmailExists)
                throw new EmailAlreadyExistsException();
            var doesLoginExists = await _userRepository.DoesLoginAlreadyExists(userToRegister.Login);
            if (doesLoginExists)
                throw new LoginAlreadyExistsException();
            return true;
        }
    }
}
