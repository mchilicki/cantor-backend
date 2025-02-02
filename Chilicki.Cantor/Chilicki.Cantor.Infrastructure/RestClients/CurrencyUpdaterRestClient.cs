﻿using Chilicki.Cantor.Infrastructure.RestClients.Base;
using RestSharp;
using Chilicki.Cantor.Infrastructure.RestClients.Helpers;
using Chilicki.Cantor.Domain.Aggregates.Currencies;
using Chilicki.Cantor.Domain.Helpers.Exceptions.Currencies;

namespace Chilicki.Cantor.Infrastructure.RestClients
{
    public class CurrencyUpdaterRestClient : ICurrencyUpdaterRestClient
    {
        private const string CURRENCIES_BASE_URL = "http://webtask.future-processing.com:8068";
        private const string CURRENCIES_URL = "currencies";

        public UpdatedCurrencies GetUpdatedCurrencies()
        {
            var client = new RestClient(CURRENCIES_BASE_URL);
            client.AddHandler("application/json", NewtonsoftJsonSerializer.Default);
            var request = new RestRequest(CURRENCIES_URL, DataFormat.Json);
            var response = client.Get<UpdatedCurrencies>(request);
            ValidateUpdatedCurrencies(response);
            return response.Data;
        }

        private bool ValidateUpdatedCurrencies(IRestResponse response)
        {
            if (!response.IsSuccessful)
            {
                throw new CannotUpdateCurrenciesException(response.ErrorMessage);
            }
            return true;
        }

    }
}
