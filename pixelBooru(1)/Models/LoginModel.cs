using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace pixelBooru_1_.Model
{
    public class LoginModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
    }
}