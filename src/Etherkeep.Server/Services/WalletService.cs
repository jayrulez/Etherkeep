using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Etherkeep.Server.Services.Models;
using System.Net.Http;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;

namespace Etherkeep.Server.Services
{
    public class WalletService : IWalletService
    {
        private IOptions<WalletServiceOptions> _options;
        private HttpClient _httpClient;
        private ILogger _logger;
        public WalletService(IOptions<WalletServiceOptions> options, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<WalletService>();

            _options = options;

            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(options.Value.BaseAddress);
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", options.Value.AccessToken);
            _httpClient.DefaultRequestHeaders.Add("env", options.Value.Environment);
        }

        public async Task<WalletModel> CreateWalletAsync(string passphrase, string label)
        {
            var data = new Dictionary<string, string>()
            {
                { "passphrase", passphrase },
                { "label", label }
            };

            if(!string.IsNullOrEmpty(_options.Value.Enterprise))
            {
                data.Add("enterprise", _options.Value.Enterprise);
            }

            if(!string.IsNullOrEmpty(_options.Value.BackupXpubProvider))
            {
                data.Add("backupXpubProvider", _options.Value.BackupXpubProvider);
            }else
            {
                throw new Exception("Parameter 'backupXpubProvider' is required.");
            }

            var response = await _httpClient.PostAsync("wallets/simplecreate", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            _logger.LogInformation($"Created wallet: {content}");

            var walletData = JObject.Parse(content);

            var model = JsonConvert.DeserializeObject<WalletModel>(walletData["wallet"].ToString());
            
            model.Data  = content;

            return model;
        }

        public async Task<WalletAddressModel> CreateWalletAddressAsync(string id, int chain)
        {
            var response = await _httpClient.PostAsync($"wallet/{id}/address/{chain}", null);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            _logger.LogInformation($"Created wallet address: {content}");

            var model = JsonConvert.DeserializeObject<WalletAddressModel>(content);

            model.Data = content;

            return model;
        }

        public async Task<WalletModel> GetWalletAsync(string id)
        {
            var response = await _httpClient.GetAsync($"wallet/{id}");

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var model = JsonConvert.DeserializeObject<WalletModel>(content);

            return model;
        }

        public async Task<WalletAddressModel> GetWalletAddressAsync(string id, string address)
        {
            var response = await _httpClient.GetAsync($"wallet/{id}/addresses/{address}");

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var model = JsonConvert.DeserializeObject<WalletAddressModel>(content);

            return model;
        }
    }
}
