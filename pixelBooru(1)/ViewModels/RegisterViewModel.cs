using System.ComponentModel.DataAnnotations;

namespace pixelBooru_1_.ViewModels
{
    public class RegisterViewModel
    {
        public int UserId { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter your username")]
        public string? UserName { get; set; }

        //Password
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter your password")]
        public string? Password { get; set; }

        //Confirm Password



        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password do not match")]
        [Required(ErrorMessage = "You must confirm your password")] 
        public string? ConfirmPassword { get; set; }

        //Email
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter your email address")]
        public string? Email { get; set; }

        [DataType(DataType.Upload)]
        [RegularExpression(@"^.*\.(jpg|jpeg|png)$", ErrorMessage = "Only JPG, JPEG, and PNG files are allowed.")]
        public byte[]? profilePicture { get; set; }

    }
}
