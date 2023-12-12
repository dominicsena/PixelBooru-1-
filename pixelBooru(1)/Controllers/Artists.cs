using Microsoft.AspNetCore.Mvc;

namespace pixelBooru_1_.Controllers
{
    public class Artists : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
