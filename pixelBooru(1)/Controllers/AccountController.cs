using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pixelBooru_1_.Data;
using pixelBooru_1_.ViewModels;


namespace pixelBooru_1_.Controllers
{
    /**public class AccountController : Controller
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


    }**/

        public class AccountController : Controller
    {

        private readonly SignInManager<users> _signInManager;
        private readonly UserManager<users> _userManager;

        public AccountController(SignInManager<users> signInManager, UserManager<users> userManager) //: this(signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Profile()
        {
            return View();
        }
        
        public IActionResult Upload()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginInfo)
        {

            var result = await _signInManager.PasswordSignInAsync(loginInfo.Username, loginInfo.Password, loginInfo.RememberMe, false);

            if (result.Succeeded)
            {

                return RedirectToAction("Index", "Home");

            }

            else
            {

                ModelState.AddModelError("", "Failed to login");

            }

            return View(loginInfo);

        }

        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");

        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel userEnteredData)
        {



            users newUser = new users();
            newUser.UserName = userEnteredData.Username;
            newUser.Email = userEnteredData.Email;

            var result = await _userManager.CreateAsync(newUser, userEnteredData.Password);

            if (result.Succeeded)
            {

                return RedirectToAction("Login", "Account");

            }

            else
            {

                foreach (var error in result.Errors)
                {

                    ModelState.AddModelError("", error.Description);

                }

            }



            return View(userEnteredData);

        }

    }

}
