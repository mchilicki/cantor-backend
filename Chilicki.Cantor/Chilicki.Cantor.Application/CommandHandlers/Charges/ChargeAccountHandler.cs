using AutoMapper;
using Chilicki.Cantor.Application.Commands.Charges;
using Chilicki.Cantor.Application.DTOs;
using Chilicki.Cantor.Domain.Services.Charges.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Users.Base;
using Chilicki.Cantor.Infrastructure.UnitsOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.CommandHandlers.Charges
{
    public class ChargeAccountHandler : IRequestHandler<ChargeAccountCommand, UserDto>
    {
        readonly IUserRepository _userRepository;
        readonly IHttpContextAccessor _httpContext;
        readonly IChargeAccountService _chargeAccountService;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;

        public ChargeAccountHandler(
            IUserRepository userRepository,
            IHttpContextAccessor httpContext,
            IChargeAccountService chargeAccountService,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _httpContext = httpContext;
            _chargeAccountService = chargeAccountService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> Handle(ChargeAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(_httpContext.HttpContext.User.Identity.Name);
            user = _chargeAccountService.ChargeUserAccount(user, request.Amount);
            await _unitOfWork.SaveAsync();
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
