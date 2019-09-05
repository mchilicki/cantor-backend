using AutoMapper;
using Chilicki.Cantor.Application.Commands.Buying;
using Chilicki.Cantor.Application.Helpers.Users.Base;
using Chilicki.Cantor.Domain.Commands.Buying;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base;

namespace Chilicki.Cantor.Application.Mappers
{
    public class BuyCurrencyCommandMapper : ITypeConverter<BuyCurrencyCommandDto, BuyCurrencyCommand>
    {
        readonly ICurrentUserService currentUserService;
        readonly ICantorWalletRepository cantorWalletRepository;

        public BuyCurrencyCommandMapper(
            ICurrentUserService currentUserService,
            ICantorWalletRepository cantorWalletRepository)
        {
            this.currentUserService = currentUserService;
            this.cantorWalletRepository = cantorWalletRepository;
        }

        public BuyCurrencyCommand Convert(BuyCurrencyCommandDto source, BuyCurrencyCommand destination, ResolutionContext context)
        {
            return new BuyCurrencyCommand()
            {
                Currency = context.Mapper.Map<Currency>(source.Currency),
                Amount = source.Amount,
                User = currentUserService.GetCurrentUser(),
                CantorWallet = cantorWalletRepository.GetCantorWallet(),
            };
        }
    }
}