using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace pixelBooru_1_.Model
{
    public class RegisterModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please Enter your UserName")]
        public string? UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter your Password")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters")]
        public string? Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Must Confirm Password")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress(ErrorMessage = "Input The Correct Email Format")]
        [Display(Name = "Email")]
        public string? Email { get; set; }
    }
}