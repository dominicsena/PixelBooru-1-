using Microsoft.AspNetCore.Mvc;

namespace pixelBooru_1_.Controllers
{
    public class ArtworkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
