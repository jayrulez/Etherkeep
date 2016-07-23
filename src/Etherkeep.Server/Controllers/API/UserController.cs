using AspNet.Security.OAuth.Validation;
using Etherkeep.Server.ViewModels.Extensions;
using Etherkeep.Server.Data;
using Etherkeep.Server.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using OpenIddict;
using Etherkeep.Server.ViewModels.Authorization;
using Etherkeep.Server.ViewModels.Shared;
using Etherkeep.Server.Data.Enums;
using Etherkeep.Server.ViewModels.Enums;
using Etherkeep.Server.ViewModels.User;

namespace Etherkeep.Server.Controllers.API
{
    [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    //[Route("api/[controller]")]
    [Route("api/users")]
    public class UserController : BaseController
    {
        public UserController(ApplicationDbContext applicationDbContext, OpenIddictUserManager<User> userManager, ILoggerFactory loggerFactory) 
            : base(applicationDbContext, userManager, loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<UserController>();
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> AccountAction()
        {
            try
            {
                var user = await GetCurrentUserAsync();

                return Ok(user.ToUserViewModel());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return BadRequest(new ErrorViewModel
                {
                    ErrorDescription = ex.Message
                });
            }
        }

        [HttpGet("me")]
        public async Task<IActionResult> MeAction()
        {
            try
            {
                var user = await GetCurrentUserAsync();

                return Ok(user.ToUserViewModel());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return BadRequest(new ErrorViewModel
                {
                    Error = "internal_error",
                    ErrorDescription = ex.Message
                });
            }
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
                        Type = UserType.Personal,
                        FirstName = model.FirstName,
                        LastName = model.LastName
                    };

                    if (model.IdentityType == IdentityType.EmailAddress)
                    {
                        await _userManager.SetEmailAsync(user, model.EmailAddress);
                        await _userManager.SetUserNameAsync(user, model.EmailAddress);

                        var emailAddress = new EmailAddress()
                        {
                            Address = model.EmailAddress,
                            Verified = false
                        };

                        user.EmailAddresses.Add(emailAddress);
                        user.PrimaryEmailAddress = new UserPrimaryEmailAddress()
                        {
                            Address = model.EmailAddress
                        };
                    }
                    else if (model.IdentityType == IdentityType.MobileNumber)
                    {
                        var phoneNumber = string.Concat(model.CountryCallingCode, "-", model.AreaCode, "-", model.SubscriberNumber);

                        await _userManager.SetPhoneNumberAsync(user, phoneNumber);
                        await _userManager.SetUserNameAsync(user, phoneNumber);

                        var mobileNumber = new MobileNumber()
                        {
                            CountryCallingCode = model.CountryCallingCode,
                            AreaCode = model.AreaCode,
                            SubscriberNumber = model.SubscriberNumber,
                            Verified = false
                        };

                        user.MobileNumbers.Add(mobileNumber);

                        user.PrimaryMobileNumber = new UserPrimaryMobileNumber()
                        {
                            CountryCallingCode = model.CountryCallingCode,
                            AreaCode = model.AreaCode,
                            SubscriberNumber = model.SubscriberNumber
                        };
                    }
                    else
                    {
                        throw new Exception("Invalid IdentityType.");
                    }

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        return Ok(user.ToUserViewModel());
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

        [AllowAnonymous, HttpPost, Route("reset_password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByNameAsync(model.EmailAddress);

                    if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                    {
                        ModelState.AddModelError("", string.Empty);
                    }
                    else
                    {

                        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                        // Send an email with this link
                        //var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                        //var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                        //await _emailSender.SendEmailAsync(model.Email, "Reset Password",
                        //   $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
                        return Ok(new { result = true });
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

        [HttpPost, Route("change_password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await GetCurrentUserAsync();

                    var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation(3, "User changed their password successfully.");

                        return Ok(new { result = true });
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
                    foreach (var error in result.Errors)
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
