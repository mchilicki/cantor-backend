using AutoMapper;
using Chilicki.Cantor.Application.Commands.Selling;
using Chilicki.Cantor.Application.DTOs;
using Chilicki.Cantor.Application.Mappers.Selling.Base;
using Chilicki.Cantor.Domain.Services.Selling.Base;
using Chilicki.Cantor.Infrastructure.UnitsOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.CommandHandlers.Selling
{
    public class SellCurrencyHandler : IRequestHandler<SellCurrencyCommandDto, UserDto>
    {
        readonly ISellCurrencyCommandMapper sellCurrencyCommandMapper;
        readonly IUnitOfWork unitOfWork;
        readonly ISellCurrencyService sellCurrencyService;
        readonly IMapper mapper;

        public SellCurrencyHandler(
            ISellCurrencyCommandMapper sellCurrencyCommandMapper,
            IUnitOfWork unitOfWork,
            ISellCurrencyService sellCurrencyService,
            IMapper mapper)
        {
            this.sellCurrencyCommandMapper = sellCurrencyCommandMapper;
            this.unitOfWork = unitOfWork;
            this.sellCurrencyService = sellCurrencyService;
            this.mapper = mapper;
        }

        public async Task<UserDto> Handle(SellCurrencyCommandDto request, CancellationToken cancellationToken)
        {
            var command = await sellCurrencyCommandMapper.Map(request);
            var user = sellCurrencyService.SellCurrency(command);
            await unitOfWork.SaveAsync();
            return mapper.Map<UserDto>(user);
        }
    }
}
