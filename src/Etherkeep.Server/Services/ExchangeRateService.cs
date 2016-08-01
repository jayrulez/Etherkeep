using Etherkeep.Data;
using Etherkeep.Server.Services.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Etherkeep.Server.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private IOptions<ExchangeRateServiceOptions> _options;
        private HttpClient _httpClient;
        private ApplicationDbContext _dbContext;
        private ILogger _logger;

        private const string _baseAddress = "https://openexchangerates.org/";

        public ExchangeRateService(IOptions<ExchangeRateServiceOptions> options, ApplicationDbContext dbContext, ILoggerFactory loggerFactory)
        {
            _options = options;
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger<ExchangeRateService>();

            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(_baseAddress);
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ExchangeRateModel> GetExchangeRateAsync(string currencyCode)
        {
            var exchangeRates = await GetExchangeRatesAsync();

            return exchangeRates.FirstOrDefault(e => e.CurrencyCode.Equals(currencyCode, StringComparison.OrdinalIgnoreCase));
        }
        public async Task<IList<ExchangeRateModel>> GetExchangeRatesAsync()
        {

            var exchangeRates = GetCached();

            if (exchangeRates == null)
            {
                var response = await _httpClient.GetAsync($"api/latest.json?app_id={_options.Value.AppId}&base={_options.Value.BaseCurrency}");

                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(content);
                }

                var rates = JsonConvert.DeserializeObject<IDictionary<string, double>>(JObject.Parse(content)["rates"].ToString());

                var currencies = _dbContext.Currencies.ToList();
                exchangeRates = new List<ExchangeRateModel>();

                foreach (var rate in rates)
                {
                    if (currencies.Any(c => c.Code.Equals(rate.Key, StringComparison.OrdinalIgnoreCase)))
                    {
                        exchangeRates.Add(new ExchangeRateModel() { CurrencyCode = rate.Key, Value = rate.Value });
                    }
                }

                SetCache(exchangeRates);
            }

            return exchangeRates;
        }

        public async Task<IList<ExchangeRateModel>> GetExchangeRatesAsync(IList<string> currencyCodes)
        {

            var exchangeRates = await GetExchangeRatesAsync();

            return exchangeRates.Where(e => currencyCodes.Contains(e.CurrencyCode)).ToList();
        }

        private IList<ExchangeRateModel> GetCached()
        {
            return null;
        }

        private void SetCache(IList<ExchangeRateModel> exchangeRates)
        {

        }
    }
}
