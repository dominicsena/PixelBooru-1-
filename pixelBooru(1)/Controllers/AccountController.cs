using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pixelBooru_1_.Data;
using pixelBooru_1_.ViewModels;


namespace pixelBooru_1_.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<users> _signInManager;
        private readonly UserManager<users> _userManager;

        public AccountController(SignInManager<users> signInManager, UserManager<users> userManager) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        
        
       [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginInfo)
        {

            var result = await _signInManager.PasswordSignInAsync(loginInfo.UserName, loginInfo.Password, loginInfo.RememberMe, false);

            if (result.Succeeded)
            {
                var user = await _userManager .FindByNameAsync(loginInfo.UserName);

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
        public async Task<IActionResult> Register(RegisterViewModel userEnteredData, IFormFile? profilePicture)
        {

            if (ModelState.IsValid)
            {
            users newUser = new users();
            newUser.UserName = userEnteredData.UserName;
            newUser.Email = userEnteredData.Email;

            if(profilePicture != null && profilePicture.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                await profilePicture.CopyToAsync(memoryStream);
                newUser.profilePicture = memoryStream.ToArray();

                }
                else
                {
                    newUser.profilePicture = null;
                }

            var result = await _userManager.CreateAsync(newUser, userEnteredData.Password);

            if (result.Succeeded)
            {
                    TempData["SuccessMessage"] = "Registration successful!, Please Login.";
                    return RedirectToAction("Login", "Account");

            }

            else
            {

                foreach (var error in result.Errors)
                {

                    ModelState.AddModelError("", error.Description);

                }
            }
            }

            return View(userEnteredData);

        }

    }

}
