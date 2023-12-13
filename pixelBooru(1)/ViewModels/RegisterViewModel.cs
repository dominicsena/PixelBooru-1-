using System.ComponentModel.DataAnnotations;

namespace pixelBooru_1_.ViewModels
{
    public class RegisterViewModel
    {

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter your username")]
        public string? Username { get; set; }

        //Password
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter your password")]
        public string? Password { get; set; }

        //Confirm Password
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must confirm your password")]
        public string? ConfirmPassword { get; set; }

        //Email
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter your email address")]
        public string? Email { get; set; }

    }
}
