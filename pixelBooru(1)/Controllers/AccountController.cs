using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// Controllers/AccountController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace pixelBooru_1_.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            // For demonstration purposes, hardcoded values are used here
           // var username = "JohnDoe";
           // var profilePictureUrl = "/images/profile.jpg";

            // Store user information in session
           // HttpContext.Session.SetString("Username", username);
          //  HttpContext.Session.SetString("ProfilePictureUrl", profilePictureUrl);

            return View();
        }

        public IActionResult Register()
        {
            // Implement registration logic here if needed
            return View();
        }

        public IActionResult Logout()
        {
            // Clear user information from session on logout
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("ProfilePictureUrl");

            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Upload()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
       
}
