using Etherkeep.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Etherkeep.Server.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private IWalletService _walletService;
        private IExchangeRateService _exchangeRateService;

        public TestController(IWalletService walletService, IExchangeRateService exchangeRateService)
        {
            _walletService = walletService;
            _exchangeRateService = exchangeRateService;
        }

        [HttpGet, Route("create_wallet")]
        public async Task<IActionResult> CreateWallet()
        {
            try
            {
                var passphrase = "testwallet";
                var label = $"test_{Guid.NewGuid().ToString()}";
                var wallet = await _walletService.CreateWalletAsync(passphrase, label);

                return Ok(wallet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("get_wallet")]
        public async Task<IActionResult> GetWallet()
        {
            try
            {
                var id = "2MzMxyewqnzFStNwiubyLgzaown552CwaUV";
                var wallet = await _walletService.GetWalletAsync(id);

                return Ok(wallet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("create_wallet_address")]
        public async Task<IActionResult> CreateWalletAddress()
        {
            try
            {
                var id = "2MzMxyewqnzFStNwiubyLgzaown552CwaUV";
                var walletAddress = await _walletService.CreateWalletAddressAsync(id, 0);

                return Ok(walletAddress);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("get_wallet_address")]
        public async Task<IActionResult> GetWalletAddress()
        {
            try
            {
                var id = "2MzMxyewqnzFStNwiubyLgzaown552CwaUV";
                var address = "2N8MEYqVvVCC8BHtp4Bes1tPDZeFwrg3FzT";
                var walletAddress = await _walletService.GetWalletAddressAsync(id, address);

                return Ok(walletAddress);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("get_exchange_rates")]
        public async Task<IActionResult> GetExchangeRates()
        {
            try
            {
                var exchangeRates = await _exchangeRateService.GetExchangeRatesAsync(new List<string>() { "USD", "JMD" });

                return Ok(exchangeRates);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
