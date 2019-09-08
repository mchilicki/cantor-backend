using AutoMapper;
using Chilicki.Cantor.Application.Commands.Buying;
using Chilicki.Cantor.Application.DTOs;
using Chilicki.Cantor.Application.Mappers.Base;
using Chilicki.Cantor.Domain.Services.Buying.Base;
using Chilicki.Cantor.Infrastructure.UnitsOfWork;
using MediatR;
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
            var command = await buyCurrencyCommandMapper.Map(request);
            var user = buyCurrencyService.BuyCurrency(command);
            await unitOfWork.SaveAsync();
            return mapper.Map<UserDto>(user);
        }
    }
}
