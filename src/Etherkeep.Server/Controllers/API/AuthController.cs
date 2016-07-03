using Etherkeep.Server.Models;
using Etherkeep.Server.Data;
using Etherkeep.Server.Data.Entities;
using Etherkeep.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using OpenIddict;

namespace Etherkeep.Server.Controllers.API
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;

        public AuthController(ApplicationDbContext applicationDbContext,
            OpenIddictUserManager<User> userManager,
            IEmailSender emailSender,
            ISmsSender smsSender,
            ILoggerFactory loggerFactory) : base(applicationDbContext, userManager, loggerFactory)
        {
            _emailSender = emailSender;
            _smsSender = smsSender;
            _logger = loggerFactory.CreateLogger<AuthController>();
        }

        private async Task<string> GenerateOtp(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var random = new Random();

            var password = random.Next(100000, 999999).ToString();

            //TODO: Remove line
            password = "123456";

            await _userManager.RemovePasswordAsync(user);
            await _userManager.AddPasswordAsync(user, password);
            await _userManager.UpdateAsync(user);

            return password;
        }

        private async Task<HttpResponseMessage> GetTokenResponse(string username, string password, string clientId, string clientSecret, string scope = null)
        {
            var httpClient = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5001/connect/token");

            var parameters = new Collection<KeyValuePair<string, string>>();

            parameters.Add(new KeyValuePair<string, string>("grant_type", "password"));
            parameters.Add(new KeyValuePair<string, string>("username", username));
            parameters.Add(new KeyValuePair<string, string>("client_id", clientId));
            parameters.Add(new KeyValuePair<string, string>("client_secret", clientSecret));
            parameters.Add(new KeyValuePair<string, string>("password", password));
            if(!string.IsNullOrEmpty(scope))
            {
                parameters.Add(new KeyValuePair<string, string>("scope", scope));
            }

            request.Content = new FormUrlEncodedContent(parameters);

            var response = await httpClient.SendAsync(request);

            return response;
        }

        [HttpPost("mobile_otp")]
        public async Task<IActionResult> MobileOtpAction([FromBody] MobileNumberLoginModel model)
        {
            try
            {
                var mobileNumber = _applicationDbContext.MobileNumbers
                    .Include(e => e.User)
                    .FirstOrDefault(e => e.CountryCallingCode.Equals(model.CountryCallingCode)
                                && e.AreaCode.Equals(model.AreaCode)
                                && e.SubscriberNumber.Equals(model.SubscriberNumber));

                if (mobileNumber != null)
                {
                    var user = mobileNumber.User;
                    
                    var password = await GenerateOtp(user);

                    await _smsSender.SendSmsAsync(mobileNumber.Canonical, $"Your auth code is: {password}");

                    return Ok();
                }
            }catch(Exception ex)
            {
                _logger.LogCritical(ex.Message);

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return BadRequest();
        }

        [HttpPost("email_otp")]
        public async Task<IActionResult> EmailOtpAction([FromBody] EmailAddressLoginModel model)
        {
            try
            {
                var emailAddress = _applicationDbContext.EmailAddresses
                    .Include(e => e.User)
                    .FirstOrDefault(e => e.Address.Equals(model.EmailAddress));

                if (emailAddress != null)
                {
                    var user = emailAddress.User;
                    
                    var password = await GenerateOtp(user);

                    await _emailSender.SendEmailAsync(emailAddress.Address, "Auth Code", $"Your auth code is: {password}");

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return BadRequest();
        }

        [HttpPost("mobile_login")]
        public async Task<IActionResult> MobileLoginAction([FromBody] MobileNumberLoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mobileNumber = _applicationDbContext.MobileNumbers
                        .Include(e => e.User)
                        .FirstOrDefault(e => e.CountryCallingCode.Equals(model.CountryCallingCode)
                            && e.AreaCode.Equals(model.AreaCode)
                            && e.SubscriberNumber.Equals(model.SubscriberNumber));

                    if (mobileNumber == null)
                    {
                        throw new Exception("Mobile number is invalid.");
                    }

                    var response = await GetTokenResponse(mobileNumber.User.UserName, model.Password, model.ClientId, model.ClientSecret, model.Scope);

                    var responseText = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        await _userManager.RemovePasswordAsync(mobileNumber.User);
                        await _userManager.UpdateAsync(mobileNumber.User);

                        return Ok(responseText);
                    }
                    else
                    {
                        return BadRequest(responseText);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("email_login")]
        public async Task<IActionResult> EmailLoginAction([FromBody] EmailAddressLoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var emailAddress = _applicationDbContext.EmailAddresses
                        .Include(e => e.User)
                        .FirstOrDefault(e => e.Address.Equals(model.EmailAddress));

                    if (emailAddress == null)
                    {
                        throw new Exception("Email address is invalid.");
                    }

                    var response = await GetTokenResponse(emailAddress.User.UserName, model.Password, model.ClientId, model.ClientSecret, model.Scope);

                    var responseText = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        await _userManager.RemovePasswordAsync(emailAddress.User);
                        await _userManager.UpdateAsync(emailAddress.User);

                        return Ok(responseText);
                    }
                    else
                    {
                        return BadRequest(responseText);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("mobile_registration")]
        public async Task<IActionResult> MobileRegistrationAction([FromBody] MobileNumberRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new User
                    {
                        UserName = Guid.NewGuid().ToString(),
                        FirstName = model.FirstName,
                        LastName = model.LastName
                    };

                    var mobileNumber = new MobileNumber
                    {
                        CountryCallingCode = model.CountryCallingCode,
                        AreaCode = model.AreaCode,
                        SubscriberNumber = model.SubscriberNumber
                    };

                    user.MobileNumbers.Add(mobileNumber);

                    user.PrimaryMobileNumber = new UserPrimaryMobileNumber
                    {
                        MobileNumber = mobileNumber
                    };

                    user.PhoneNumber = mobileNumber.Canonical;

                    var result = await _userManager.CreateAsync(user, Guid.NewGuid().ToString());

                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("email_registration")]
        public async Task<IActionResult> EmailRegistrationAction([FromBody] EmailAddressRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new User
                    {
                        UserName = Guid.NewGuid().ToString(),
                        FirstName = model.FirstName,
                        LastName = model.LastName
                    };

                    var emailAddress = new EmailAddress
                    {
                        Address = model.EmailAddress,
                        CreatedAt = DateTime.UtcNow,
                        Verified = false
                    };

                    user.EmailAddresses.Add(emailAddress);

                    user.PrimaryEmailAddress = new UserPrimaryEmailAddress
                    {
                        EmailAddress = emailAddress
                    };

                    user.Email = emailAddress.Address;

                    var result = await _userManager.CreateAsync(user, Guid.NewGuid().ToString());

                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
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
