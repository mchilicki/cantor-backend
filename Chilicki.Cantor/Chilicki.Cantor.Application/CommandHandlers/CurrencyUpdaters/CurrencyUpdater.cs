using Chilicki.Cantor.Application.CommandHandlers.CurrencyUpdaters.Base;
using Chilicki.Cantor.Domain.Aggregates;
using Chilicki.Cantor.Domain.Aggregates.Currencies;
using Chilicki.Cantor.Domain.Entities;
using Chilicki.Cantor.Domain.Factories.Initializing.Base;
using Chilicki.Cantor.Domain.Services.Currencies.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Cantors.Base;
using Chilicki.Cantor.Infrastructure.Repositories.Currencies.Base;
using Chilicki.Cantor.Infrastructure.RestClients.Base;
using Chilicki.Cantor.Infrastructure.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chilicki.Cantor.Application.CommandHandlers.CurrencyUpdaters
{
    public class CurrencyUpdater : ICurrencyUpdater
    {
        readonly ICurrencyRepository currencyRepository;
        readonly ICantorCurrencyRepository cantorCurrencyRepository;
        readonly ICurrencyUpdaterRestClient currencyUpdaterRestClient;
        readonly ICantorWalletRepository cantorWalletRepository;
        readonly ICurrencyUpdateService currencyUpdateService;
        readonly IUnitOfWork unitOfWork;
        readonly IInitializeCurrenciesFactory initializeCurrenciesFactory;

        public CurrencyUpdater(
            ICurrencyRepository currencyRepository,
            ICantorCurrencyRepository cantorCurrencyRepository,
            ICurrencyUpdaterRestClient currencyUpdaterRestClient,
            ICantorWalletRepository cantorWalletRepository,
            ICurrencyUpdateService currencyUpdateService,
            IUnitOfWork unitOfWork,
            IInitializeCurrenciesFactory initializeCurrenciesFactory)
        {
            this.currencyRepository = currencyRepository;
            this.cantorCurrencyRepository = cantorCurrencyRepository;
            this.currencyUpdaterRestClient = currencyUpdaterRestClient;
            this.cantorWalletRepository = cantorWalletRepository;
            this.currencyUpdateService = currencyUpdateService;
            this.unitOfWork = unitOfWork;
            this.initializeCurrenciesFactory = initializeCurrenciesFactory;
        }

        public async Task<bool> InitializeAndUpdateCurrencies()
        {
            if (await AreCurrenciesNotInitialized())
            {
                await InitializeCurrencies();
            }
            bool wereCurrenciesUpdated = await UpdateCurrencies();
            return wereCurrenciesUpdated;
        }

        public async Task InitializeCurrencies()
        {
            var defaultCantorWallet = initializeCurrenciesFactory.CreateDefaultCantorWallet();
            await cantorWalletRepository.AddAsync(defaultCantorWallet);
            var defaultCurrencies = initializeCurrenciesFactory.CreateDefaultCurrencies();
            await currencyRepository.AddRangeAsync(defaultCurrencies);
            var defaultCantorCurrencies = initializeCurrenciesFactory.CreateDefaultCantorCurrencies(defaultCantorWallet, defaultCurrencies);
            await cantorCurrencyRepository.AddRangeAsync(defaultCantorCurrencies);
            await unitOfWork.SaveAsync();
        }

        public async Task<bool> UpdateCurrencies()
        {
            var updatedCurrencies = currencyUpdaterRestClient.GetUpdatedCurrencies();
            var cantorWallet = await cantorWalletRepository.GetCantorWalletAsync();
            if (!ShouldUpdateCurrencies(cantorWallet, updatedCurrencies))
                return false;
            var allCurrencies = await currencyRepository.GetAllAsync();
            var remainingCurrencies = currencyUpdateService.UpdateCurrencies(cantorWallet, allCurrencies, updatedCurrencies);
            await currencyRepository.AddRangeAsync(remainingCurrencies.Items);
            await unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> AreCurrenciesNotInitialized()
        {
            var cantorWalletsCount = await cantorWalletRepository.GetCountAsync();
            return cantorWalletsCount == 0;
        }

        private bool ShouldUpdateCurrencies(CantorWallet cantorWallet, UpdatedCurrencies updatedCurrencies)
        {
            return cantorWallet.PublicationDate != updatedCurrencies.PublicationDate;
        }
    }
}
