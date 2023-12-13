using Microsoft.AspNetCore.Mvc;

namespace pixelBooru_1_.Controllers
{
    public class ArtistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}
