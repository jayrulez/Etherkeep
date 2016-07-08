using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNet.Security.OAuth.Validation;
using System;
using Etherkeep.Server.ViewModels;
using Etherkeep.Server.ViewModels.Extensions;
using Etherkeep.Server.Services;
using Etherkeep.Server.Data;
using Etherkeep.Server.Data.Entities;
using Etherkeep.Server.Data.Repository;
using OpenIddict;
using Etherkeep.Server.ViewModels.Authorization;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using Etherkeep.Server.Models;
using Etherkeep.Server.Models.Extensions;

namespace Etherkeep.Server.Controllers.API
{
    [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;

        public AccountController(
            ApplicationDbContext applicationDbContext,
            OpenIddictUserManager<User> userManager,
            IEmailSender emailSender,
            ISmsSender smsSender,
            ILoggerFactory loggerFactory) : base(applicationDbContext, userManager, loggerFactory)
        {
            _emailSender = emailSender;
            _smsSender = smsSender;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        [HttpGet, Route("activities")]
        public async Task<IActionResult> ActivitiesAction(int? page)
        {
            try
            {
                int pageNumber = page ?? 1;

                int pageSize = 10;

                var user = await GetCurrentUserAsync();

                var activities = _applicationDbContext.Activities.Where(e => e.UserId == user.Id);

                var result = new PagedResult<ActivityViewModel>
                {
                    TotalCount = activities.Count(),
                    Items = activities.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToViewModel()
                };

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return BadRequest(ModelState);
        }

        [HttpGet, Route("balance")]
        public async Task<IActionResult> BalanceAction()
        {
            try
            {
                var user = await GetCurrentUserAsync();

                var wallet = _applicationDbContext.Wallets.Where(e => e.UserId.Equals(user.Id)).FirstOrDefault();

                if (wallet == null)
                {
                    return BadRequest();
                }

                return Ok(wallet.Balance);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return BadRequest(ModelState);
        }

        [AllowAnonymous, HttpPost, Route("login")]
        public async Task<IActionResult> LoginAction([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = model.LoginMode == LoginMode.EmailAddress
                        ? await _userManager.FindByEmailAsync(model.EmailAddress) : model.LoginMode == LoginMode.MobileNumber
                        ? await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.PhoneNumber.Equals(string.Concat(model.CountryCallingCode, model.AreaCode, model.SubscriberNumber))) : null;

                    if (user == null)
                    {
                        throw new Exception(string.Format("{0} was not found.", model.LoginMode == LoginMode.EmailAddress ? "Email Address" : "Mobile Number"));
                    }

                    var parameters = new Collection<KeyValuePair<string, string>>();

                    parameters.Add(new KeyValuePair<string, string>("grant_type", "password"));
                    parameters.Add(new KeyValuePair<string, string>("username", user.UserName));
                    parameters.Add(new KeyValuePair<string, string>("password", model.Password));

                    if (!string.IsNullOrEmpty(model.ClientId))
                    {
                        parameters.Add(new KeyValuePair<string, string>("client_id", model.ClientId));
                    }

                    if (!string.IsNullOrEmpty(model.ClientSecret))
                    {
                        parameters.Add(new KeyValuePair<string, string>("client_secret", model.ClientSecret));
                    }

                    if (!string.IsNullOrEmpty(model.Scope))
                    {
                        parameters.Add(new KeyValuePair<string, string>("scope", model.Scope));
                    }

                    using (var httpClient = new HttpClient())
                    {
                        httpClient.BaseAddress = new Uri(Request.IsHttps ? "https" : "http" + "://" + Request.Host.ToString());

                        var request = new HttpRequestMessage(HttpMethod.Post, "connect/token");

                        request.Content = new FormUrlEncodedContent(parameters);

                        var response = await httpClient.SendAsync(request);

                        if (response.IsSuccessStatusCode)
                        {
                            return Ok(new ResponseModel<string>(await response.Content.ReadAsStringAsync()));
                        }
                        else
                        {
                            return BadRequest(new ResponseModel<string>(await response.Content.ReadAsStringAsync()));
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest(ModelState.GetErrorResponse());
        }

        [AllowAnonymous, HttpPost, Route("register")]
        public async Task<IActionResult> RegisterAction([FromBody] RegisterViewModel model)
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

                    if (model.RegisterMode == RegisterMode.EmailAddress)
                    {
                        user.Email = model.EmailAddress;
                    }
                    else if (model.RegisterMode == RegisterMode.MobileNumber)
                    {
                        user.PhoneNumber = string.Concat(model.CountryCallingCode, model.AreaCode, model.SubscriberNumber);
                    }
                    else
                    {
                        throw new Exception("Invalid RegistrationMode.");
                    }

                    var result = await _userManager.CreateAsync(user, Guid.NewGuid().ToString());

                    if (result.Succeeded)
                    {
                        return Ok(new ResponseModel<User>(user));
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

            return BadRequest(ModelState.GetErrorResponse());
        }

        [HttpPost, Route("change_email")]
        public IActionResult ChangeEmailAction()
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

            return BadRequest(ModelState.GetErrorResponse());
        }

        [AllowAnonymous, HttpGet, Route("confirm_email")]
        public async Task<IActionResult> ConfirmEmailAction(Guid userId, string code)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());

                if (user == null)
                {
                    return BadRequest(new ErrorViewModel
                    {
                        Error = "",
                        ErrorDescription = ""
                    });
                }

                var result = await _userManager.ConfirmEmailAsync(user, code);

                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return BadRequest(ModelState.GetErrorResponse());
        }

        [HttpPost, Route("change_phone_number")]
        public IActionResult ChangePhoneNumberAction()
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

            return BadRequest(ModelState.GetErrorResponse());
        }

        [HttpPost, Route("confirm_phone_number")]
        public IActionResult ConfirmPhoneNumberAction()
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

            return BadRequest(ModelState.GetErrorResponse());
        }
    }
}
