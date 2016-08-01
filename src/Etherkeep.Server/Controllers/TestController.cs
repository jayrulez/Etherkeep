using Etherkeep.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Controllers
{
    [Route("api/[controller]")]
    public class TestController: Controller
    {
        private IWalletService _walletService;

        public TestController(IWalletService walletService)
        {
            _walletService = walletService;
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
