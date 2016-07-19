using AspNet.Security.OAuth.Validation;
using Etherkeep.Server.Models;
using Etherkeep.Server.Data;
using Etherkeep.Server.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenIddict;

namespace Etherkeep.Server.Controllers.API
{
    [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class PaymentController : BaseController
    {
        public PaymentController(ApplicationDbContext applicationDbContext, OpenIddictUserManager<User> userManager, ILoggerFactory loggerFactory) 
            : base(applicationDbContext, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PaymentController>();
        }

        [Route("request")]
        public async Task<IActionResult> RequestAction([FromBody] RequestTransferViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var request = new PaymentRequest();

                    _applicationDbContext.PaymentRequests.Add(request);

                    await _applicationDbContext.SaveChangesAsync();

                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [Route("request_external")]
        public async Task<IActionResult> RequestInvitationAction([FromBody] RequestTransferInvitationViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var request = new ExternalPaymentRequest();

                    _applicationDbContext.ExternalPaymentRequests.Add(request);

                    await _applicationDbContext.SaveChangesAsync();
                    
                    return Ok();
                }
                catch (Exception ex)
                {

                    _logger.LogCritical(ex.Message);
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [Route("send")]
        public IActionResult SendAction([FromBody] SendTransferViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [Route("send_external")]
        public IActionResult SendInvitationAction([FromBody] SendTransferInvitationViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [Route("{id:int}/accept")]
        public IActionResult AcceptAction(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [Route("{id:int}/pay")]
        public IActionResult PayAction(int id, [FromBody] PayTransferViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [Route("{id:int}/cancel")]
        public IActionResult CancelAction(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("{id:int}/cancel_external")]
        public IActionResult CancelInvitationAction(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("{id:int}/reject")]
        public IActionResult RejectAction(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet("{id:int}")]
        public IActionResult PaymentDetailsAction(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet("external/{id:int}")]
        public IActionResult ExternalPaymentDetailsAction(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet("request/{id:int}")]
        public IActionResult PaymentRequestDetailsAction(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet("external_request/{id:int}")]
        public IActionResult ExternalPaymentRequestDetailsAction(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }
    }
}
