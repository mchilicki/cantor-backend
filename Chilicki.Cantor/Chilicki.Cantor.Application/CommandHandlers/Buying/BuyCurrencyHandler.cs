using AutoMapper;
using Chilicki.Cantor.Application.Commands.Buying;
using Chilicki.Cantor.Application.DTOs;
using Chilicki.Cantor.Application.Helpers.Users.Base;
using Chilicki.Cantor.Application.Mappers.Base;
using Chilicki.Cantor.Domain.Commands.Buying;
using Chilicki.Cantor.Domain.Services.Buying.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Users.Base;
using Chilicki.Cantor.Infrastructure.UnitsOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.CommandHandlers.Buying
{
    public class BuyCurrencyHandler : IRequestHandler<BuyCurrencyCommandDto, UserDto>
    {
        readonly IMapper mapper;
        readonly IBuyCurrencyService buyCurrencyService;
        readonly IUnitOfWork unitOfWork;
        readonly IBuyCurrencyCommandMapper buyCurrencyCommandMapper;

        public BuyCurrencyHandler(
            IMapper mapper,
            IBuyCurrencyService buyCurrencyService,
            IUnitOfWork unitOfWork,
            IBuyCurrencyCommandMapper buyCurrencyCommandMapper)
        {
            this.mapper = mapper;
            this.buyCurrencyService = buyCurrencyService;
            this.unitOfWork = unitOfWork;
            this.buyCurrencyCommandMapper = buyCurrencyCommandMapper;
        }

        public async Task<UserDto> Handle(BuyCurrencyCommandDto request, CancellationToken cancellationToken)
        {
            var command = buyCurrencyCommandMapper.Map(request);
            var user = buyCurrencyService.BuyCurrency(command);
            await unitOfWork.SaveAsync();
            return mapper.Map<UserDto>(user);
        }
    }
}
