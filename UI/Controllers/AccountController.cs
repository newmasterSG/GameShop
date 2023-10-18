using Application.Services;
using Domain.Interfaces;
using Domain.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;
using UI.Models.User;
using UI.Validate;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private ILogger<AccountController> _logger;
        private readonly EmailSender _emailSender;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHtmlLocalizer<AccountController> _localizer;
        private readonly IStringLocalizer<ValidationResources> _sharedLocalizer;
        public AccountController(ILogger<AccountController> logger,
            UserManager<UserEntity> userManager, 
            SignInManager<UserEntity> signInManager,
            EmailSender emailSender,
            IWebHostEnvironment webHostEnvironment,
            IHtmlLocalizer<AccountController> localizer,
            IStringLocalizer<ValidationResources> stringLocalizer
            )
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _webHostEnvironment = webHostEnvironment;
            _localizer = localizer;
            _sharedLocalizer = stringLocalizer;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(await _userManager.FindByEmailAsync(model.Email) is null)
                {
                    var user = new UserEntity { UserName = model.Email, Email = model.Email, DateRegistration = DateTime.Now };
                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Buyer"));
                        await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Name, user.UserName));
                        await _userManager.AddToRoleAsync(user, "Buyer");

                        await _signInManager.SignInAsync(user, isPersistent: false);

                        // Generate email confirmation token
                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                        // Generate a confirmation link
                        var confirmationLink = Url.Action("EmailConfirmed", "Account", new { userId = user.Id, token }, Request.Scheme);

                        // Load the HTML template "Path/To/Your/EmailConfirmationSent.cshtml"
                        var htmlTemplate = System.IO.File.ReadAllText(Path.Combine(_webHostEnvironment.ContentRootPath + "/Contents/EmailConfirmationSent.cshtml"));

                        // Replace the placeholder with the actual link
                        htmlTemplate = htmlTemplate.Replace("{{CONFIRMATION_LINK}}", confirmationLink);

                        await _emailSender.SendEmailAsync(model.Email, "", "Confirm Your Email",
                            htmlTemplate, true);

                        // Redirect to a page informing the user to check their email
                        return View("EmailConfirmationSent");

                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError("", $"User has already created");
                    return View();
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            // Создать челлендж для аутентификации
            var props = new AuthenticationProperties
            {
                RedirectUri = returnUrl
            };

            return Challenge(props,"oidc");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            var title = _localizer["ForgotPasswordTitle"];
            var resetButton = _localizer["RestoreButton"];
            ViewBag.Title = title;
            ViewBag.ResetButton = resetButton;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Не верные данны");
                return View();
            }

            if(string.IsNullOrEmpty(viewModel.Email))
            {
                ModelState.AddModelError("", "Empty field");
                return View();
            }

            var user = await _userManager.FindByEmailAsync(viewModel.Email);

            if (user == null)
            {
                ModelState.AddModelError("", $"User is not found");
                return View();
            }

            // Отправка ссылки с токеном на восстановление пароля
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Generate a confirmation link
            var confirmationLink = Url.Action("ResetPassword", "Account", new { userId = user.Id, token }, Request.Scheme);

            // Load the HTML template "Path/To/Your/EmailConfirmationSent.cshtml"
            var htmlTemplate = System.IO.File.ReadAllText(Path.Combine(_webHostEnvironment.ContentRootPath + "/Contents/RecoveryPassword.cshtml"));

            // Replace the placeholder with the actual link
            htmlTemplate = htmlTemplate.Replace("{{CONFIRMATION_LINK}}", confirmationLink);

            await _emailSender.SendEmailAsync(user.Email, null, "Password recovery",
                htmlTemplate, true);

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string email, string token)
        {
            var resetButton = _localizer["ChangeButton"];
            ViewBag.ResetButton = resetButton;
            var model = new ResetPasswordViewModel
            {
                Email = email,
                Token = token
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = await _userManager.FindByEmailAsync(viewModel.Email);
            if(user == null)
            {
                ModelState.AddModelError("","Not found");
                return View();
            }

            await _userManager.ResetPasswordAsync(user, viewModel.Token ,viewModel.NewPassword);

            return RedirectToAction("PasswordChangedConfirmation");
        }

        [HttpGet]
        public IActionResult PasswordResetConfirmation()
        {
            var title = _localizer["PasswordChangeSuccess"];
            var message = _localizer["SuccessfullyChangedMessage"];

            ViewBag.Title = title;
            ViewBag.Message = message;

            return View();
        }

        public IActionResult PasswordChangedConfirmation()
        {
            var title = _localizer["PasswordRecoveryConfirmationTitle"];
            var message = _localizer["RecoveryMessage"];

            ViewBag.Title = title;
            ViewBag.Message = message;

            return View();
        }

        [HttpGet]
        public IActionResult EmailConfirmationFailed()
        {
            var title = _localizer["EmailConfirmationFailed"];
            var sorry = _localizer["ConfirmationProcessHasFailed"];

            ViewBag.Title = title;
            ViewBag.Sorry = sorry;

            return View();
        }

        [HttpGet]
        public IActionResult EmailConfirmationSent()
        {
            var title = _localizer["EmailConfirmationSent"];
            var success = _localizer["ConfirmationLinkSuccess"];

            ViewBag.Title = title;
            ViewBag.Success = success;

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> EmailConfirmed(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                // Email confirmed successfully, you can redirect to a page with a success message
                var title = _localizer["EmailConfirmed"];
                var success = _localizer["ConfirmMessage"];

                ViewBag.Title = title;
                ViewBag.Success = success;

                return View("EmailConfirmed");
            }
            else
            {
                // Email confirmation failed, you can redirect to a page with an error message
                return View("EmailConfirmationFailed");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut(string returnUrl = null)
        {
            return SignOut(CookieAuthenticationDefaults.AuthenticationScheme, "oidc");

        }
    }
}
