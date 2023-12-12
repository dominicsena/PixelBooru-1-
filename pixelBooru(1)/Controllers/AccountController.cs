using Microsoft.AspNetCore.Mvc;

namespace pixelBooru_1_.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }

        public IActionResult Upload()
        {
            return View();
        }
    }
}
