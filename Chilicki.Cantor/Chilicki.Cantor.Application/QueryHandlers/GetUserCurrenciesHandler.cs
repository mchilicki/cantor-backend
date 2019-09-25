using AutoMapper;
using Chilicki.Cantor.Application.DTOs;
using Chilicki.Cantor.Application.Helpers.Users.Base;
using Chilicki.Cantor.Application.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.QueryHandlers
{
    public class GetUserCurrenciesHandler : IRequestHandler<GetUserCurrenciesQuery, UserDto>
    {
        readonly IMapper mapper;
        readonly ICurrentUserService currentUserService;

        public GetUserCurrenciesHandler(
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            this.mapper = mapper;
            this.currentUserService = currentUserService;
        }

        public async Task<UserDto> Handle(GetUserCurrenciesQuery request, CancellationToken cancellationToken)
        {
            var user = await currentUserService.GetCurrentUserAsync();
            var userDto = mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
