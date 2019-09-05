using AutoMapper;
using Chilicki.Cantor.Application.Commands.Buying;
using Chilicki.Cantor.Application.DTOs;
using Chilicki.Cantor.Application.Helpers.Users.Base;
using Chilicki.Cantor.Domain.Commands.Buying;
using Chilicki.Cantor.Domain.Services.Buying.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.CommandHandlers.Buying
{
    public class BuyCurrencyHandler : IRequestHandler<BuyCurrencyCommandDto, UserDto>
    {
        readonly ICurrencyRepository currencyRepository;
        readonly ICurrentUserService currentUserService;
        readonly IMapper mapper;
        readonly IBuyCurrencyService buyCurrencyService;

        public BuyCurrencyHandler(
            ICurrencyRepository currencyRepository,
            ICurrentUserService currentUserService,
            IMapper mapper,
            IBuyCurrencyService buyCurrencyService)
        {
            this.currencyRepository = currencyRepository;
            this.currentUserService = currentUserService;
            this.mapper = mapper;
            this.buyCurrencyService = buyCurrencyService;
        }

        public async Task<UserDto> Handle(BuyCurrencyCommandDto request, CancellationToken cancellationToken)
        {
            var command = mapper.Map<BuyCurrencyCommand>(request);
            var user = buyCurrencyService.BuyCurrency(command);
            return mapper.Map<UserDto>(user);
        }
    }
}
