using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using UI.Validate;

namespace UI.Models.User
{
    public class UserModelValid
    {
        [Required(ErrorMessageResourceName = "UserNameRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [Display(Name = "Имя пользователя")]
        public string Username { get; set; }

        [Required(ErrorMessage = "PasswordRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "EmailRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email", ResourceType = typeof(ValidationResources))]
        public string Email { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "EmailRequired")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PasswordRequired")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "DontMatch")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "EmailRequired")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PasswordRequired")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [BindProperty]
        [Required(ErrorMessage = "EmailRequired")]
        [EmailAddress(ErrorMessage = "InvalidEmail")]
        public string Email { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [BindProperty]
        [Required(ErrorMessage = "PasswordRequired")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "ConfirmPasswordRequired")]
        [Compare("NewPassword", ErrorMessage = "DontMatch")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Token { get; set; }
    }
}
