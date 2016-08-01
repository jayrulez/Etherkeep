using Etherkeep.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Etherkeep.Server.Services.Models;
using Etherkeep.Data;
using System.Net.Http;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Etherkeep.Server.Services
{
    public class WalletService : IWalletService
    {
        private IOptions<WalletServiceOptions> _options;
        private HttpClient _httpClient;
        public WalletService(IOptions<WalletServiceOptions> options)
        {
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

            var walletData = JObject.Parse(content);

            var model = new WalletModel();

            model.Id    = walletData["wallet"]["id"].ToString();
            model.Label = walletData["wallet"]["label"].ToString();
            model.Data  = content;

            return model;
        }

        public WalletAddressModel CreateWalletAddress(string id)
        {
            return new WalletAddressModel()
            {
            };
        }

        public WalletModel FindWalletById(string id)
        {
            return new WalletModel()
            {
                Id = Guid.NewGuid().ToString()
            };
        }
    }
}
