using MemberRegistration.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string Action { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class ManageUserViewModel
    {
        [CustomRequired]
        [DataType(DataType.Password)]
        [Display(Name = "Trenutna lozinka")]
        public string OldPassword { get; set; }

        [CustomRequired]
        [StringLength(100, ErrorMessage = "Lozinka mora imati barem {2} znakova.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova lozinka")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi novu lozinku")]
        [Compare("NewPassword", ErrorMessage = "Nova lozinka i potvrda lozinke nisu jednake.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [CustomRequired]
        [Display(Name = "Korisničko ime")]
        public string UserName { get; set; }

        [CustomRequired]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [CustomRequired]
        public string UserName { get; set; }

        [CustomRequired]
        [EmailAddress]
        public string Email { get; set; }

        [CustomRequired]
        [StringLength(100, ErrorMessage = "Lozinka mora imati barem {2} znakova.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("Password", ErrorMessage = "Nova lozinka i potvrda lozinke nisu jednake.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [CustomRequired]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [CustomRequired]
        [StringLength(100, ErrorMessage = "Lozinka mora imati barem {2} znakova.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("Password", ErrorMessage = "Nova lozinka i potvrda lozinke nisu jednake.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [CustomRequired]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    /// <summary>
    /// ViewModel for roles.
    /// </summary>
    public class RoleViewModel
    {
        [CustomRequired]
        [Display(Name = "Naziv uloge")]
        public string Name { get; set; }
    }

    /// <summary>
    /// View model for reset another user password.
    /// </summary>
    public class ResetUserPasswordViewModel
    {
        [CustomRequired]
        [Display(Name = "Korisnik")]
        public Guid UserId { get; set; }

        [CustomRequired]
        [Display(Name = "Nova lozinka")]
        [StringLength(100, ErrorMessage = "Lozinka mora imati barem {2} znakova.", MinimumLength = 6)]
        public string NewPassword { get; set; }
    }
}

