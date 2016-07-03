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
    public class TransferController : BaseController
    {
        public TransferController(ApplicationDbContext applicationDbContext, OpenIddictUserManager<User> userManager, ILoggerFactory loggerFactory) 
            : base(applicationDbContext, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<TransferController>();
        }

        [Route("request")]
        public async Task<IActionResult> RequestAction([FromBody] RequestTransferModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var transfer = new Transfer();

                    _applicationDbContext.Transfers.Add(transfer);

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

        [Route("request_invitation")]
        public async Task<IActionResult> RequestInvitationAction([FromBody] RequestTransferInvitationModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var transferInvitation = new TransferInvitation();

                    _applicationDbContext.TransferInvitations.Add(transferInvitation);

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
        public IActionResult SendAction([FromBody] SendTransferModel model)
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

        [Route("send_invitation")]
        public IActionResult SendInvitationAction([FromBody] SendTransferInvitationModel model)
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
        public IActionResult PayAction(int id, [FromBody] PayTransferModel model)
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

        [HttpPost("{id:int}/cancel_invitation")]
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

        [HttpGet("{id:int}/details")]
        public IActionResult DetailsAction(int id)
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

        [HttpGet("{id:int}/invitation_details")]
        public IActionResult InvitationDetailsAction(int id)
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

        [HttpPost("{id:int}/send_message")]
        public IActionResult SendMessageAction(int id, [FromBody] SendTransferMessageModel model)
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

        [HttpPost("{id:int}/send_invitation_message")]
        public IActionResult SendInvitationMessageAction(int id, [FromBody] SendTransferInvitationMessageModel model)
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

        [HttpGet("{id:int}/messages")]
        public IActionResult MessagesAction(int id)
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

        [HttpGet("{id:int}/invitation_messages")]
        public IActionResult InvitationMessagesAction(int id)
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
