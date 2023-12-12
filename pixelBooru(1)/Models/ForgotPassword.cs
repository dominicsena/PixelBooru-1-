using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace pixelBooru_1_.Models
{
    public class ForgotPassword : Controller
    {
        public class RegisterModel
        {
            [Display(Name = "User Name")]
            [Required(ErrorMessage = "Please Enter your UserName")]
            public string? UserName { get; set; }

            [Display(Name = "New Password")]
            [Required(ErrorMessage = "Please Enter your New Password")]
            [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters")]
            public string? NewPassword { get; set; }

            [Display(Name = "New Confirm Password")]
            [Required(ErrorMessage = "Confirm your New Password")]
            public string? NewConfirmPassword { get; set; }

            [Required(ErrorMessage = "Please enter Email")]
            [EmailAddress(ErrorMessage = "Input The Correct Email Format")]
            [Display(Name = "Email")]
            public string? Email { get; set; }
        }
    }
} 
