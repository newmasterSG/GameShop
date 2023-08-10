using Application.Services;
using Domain.Interfaces;
using Infrastructure.UnitOfWork.Interface;
using Infrastructure.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using UI.Models.User;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private ILogger<AccountController> _logger;
        private AccountServices _accountServices;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AccountController(ILogger<AccountController> logger,
            AccountServices accountServices, 
            UserManager<UserModel> userManager, 
            SignInManager<UserModel> signInManager,
            IEmailSender emailSender,
            IWebHostEnvironment webHostEnvironment)
        {
            _accountServices = accountServices;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: AccountController
        public ActionResult Index()
        {
            return View();
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
                    var user = new UserModel { UserName = model.Email, Email = model.Email, };
                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "User"));
                        await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Name, user.UserName));

                        await _signInManager.SignInAsync(user, isPersistent: false);

                        // Generate email confirmation token
                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                        // Generate a confirmation link
                        var confirmationLink = Url.Action("EmailConfirmed", "Account", new { userId = user.Id, token }, Request.Scheme);

                        // Load the HTML template "Path/To/Your/EmailConfirmationSent.cshtml"
                        var htmlTemplate = System.IO.File.ReadAllText(Path.Combine(_webHostEnvironment.ContentRootPath + "/Contents/EmailConfirmationSent.cshtml"));

                        // Replace the placeholder with the actual link
                        htmlTemplate = htmlTemplate.Replace("{{CONFIRMATION_LINK}}", confirmationLink);

                        await _emailSender.SendEmailAsync(model.Email, null, "Confirm Your Email",
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
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if(user.EmailConfirmed == false)
                {
                    ModelState.AddModelError("", $"User not confirmed email");
                    return View();
                }

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: true);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home"); // Redirect to home page after successful login
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
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

            return View("RedirectToPage");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string email, string token)
        {
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
            return View();
        }

        [HttpGet]
        public IActionResult EmailConfirmationFailed()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EmailConfirmationSent()
        {
            return View();
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
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
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }
    }
}
