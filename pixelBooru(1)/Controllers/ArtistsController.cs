using Microsoft.AspNetCore.Mvc;

namespace pixelBooru_1_.Controllers
{
    public class ArtistsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
