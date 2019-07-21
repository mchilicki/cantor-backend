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
        readonly ICurrencyRepository _currencyRepository;
        readonly ICantorCurrencyRepository _cantorCurrencyRepository;
        readonly ICurrencyUpdaterRestClient _currencyUpdaterRestClient;
        readonly ICantorWalletRepository _cantorWalletRepository;
        readonly ICurrencyUpdateService _currencyUpdateService;
        readonly IUnitOfWork _unitOfWork;
        readonly IInitializeCurrenciesFactory _initializeCurrenciesFactory;

        public CurrencyUpdater(
            ICurrencyRepository currencyRepository,
            ICantorCurrencyRepository cantorCurrencyRepository,
            ICurrencyUpdaterRestClient currencyUpdaterRestClient,
            ICantorWalletRepository cantorWalletRepository,
            ICurrencyUpdateService currencyUpdateService,
            IUnitOfWork unitOfWork,
            IInitializeCurrenciesFactory initializeCurrenciesFactory)
        {
            _currencyRepository = currencyRepository;
            _cantorCurrencyRepository = cantorCurrencyRepository;
            _currencyUpdaterRestClient = currencyUpdaterRestClient;
            _cantorWalletRepository = cantorWalletRepository;
            _currencyUpdateService = currencyUpdateService;
            _unitOfWork = unitOfWork;
            _initializeCurrenciesFactory = initializeCurrenciesFactory;
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
            var defaultCantorWallet = _initializeCurrenciesFactory.CreateDefaultCantorWallet();
            await _cantorWalletRepository.AddAsync(defaultCantorWallet);
            var defaultCurrencies = _initializeCurrenciesFactory.CreateDefaultCurrencies();
            await _currencyRepository.AddRangeAsync(defaultCurrencies);
            var defaultCantorCurrencies = _initializeCurrenciesFactory.CreateDefaultCantorCurrencies(defaultCantorWallet, defaultCurrencies);
            await _cantorCurrencyRepository.AddRangeAsync(defaultCantorCurrencies);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> UpdateCurrencies()
        {
            var updatedCurrencies = _currencyUpdaterRestClient.GetUpdatedCurrencies();
            var cantorWallet = await _cantorWalletRepository.GetCantor();
            if (!ShouldUpdateCurrencies(cantorWallet, updatedCurrencies))
                return false;
            var allCurrencies = await _currencyRepository.GetAllAsync();
            var remainingCurrencies = _currencyUpdateService.UpdateCurrencies(cantorWallet, allCurrencies, updatedCurrencies);
            await _currencyRepository.AddRangeAsync(remainingCurrencies.Items);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> AreCurrenciesNotInitialized()
        {
            var cantorWalletsCount = await _cantorWalletRepository.GetCountAsync();
            return cantorWalletsCount == 0;
        }

        private bool ShouldUpdateCurrencies(CantorWallet cantorWallet, UpdatedCurrencies updatedCurrencies)
        {
            return cantorWallet.PublicationDate != updatedCurrencies.PublicationDate;
        }
    }
}
