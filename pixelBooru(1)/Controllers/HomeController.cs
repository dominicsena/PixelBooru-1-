using Microsoft.AspNetCore.Mvc;
using pixelBooru_1_.Data;
using pixelBooru_1_.Models;
using System.Diagnostics;

namespace pixelBooru_1_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbData;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbData)
        {
            _dbData = dbData;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var artworkList = _dbData.Artworks.ToList();

            return View(artworkList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Artist()
        {
            return View();
        }
    }
}