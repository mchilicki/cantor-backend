﻿using AutoMapper;
using Chilicki.Cantor.Application.Commands.Charges;
using Chilicki.Cantor.Application.DTOs;
using Chilicki.Cantor.Application.Helpers.Users.Base;
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
        readonly ICurrentUserService currentUserService;
        readonly IChargeAccountService chargeAccountService;
        readonly IMapper mapper;
        readonly IUnitOfWork unitOfWork;

        public ChargeAccountHandler(
            ICurrentUserService currentUserService,
            IChargeAccountService chargeAccountService,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.currentUserService = currentUserService;
            this.chargeAccountService = chargeAccountService;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<UserDto> Handle(ChargeAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await currentUserService.GetCurrentUser();
            user = chargeAccountService.ChargeUserAccount(user, request.Amount);
            await unitOfWork.SaveAsync();
            var userDto = mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
