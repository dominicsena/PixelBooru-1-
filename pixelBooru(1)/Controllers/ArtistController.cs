using Microsoft.AspNetCore.Mvc;
using pixelBooru_1_.Data;

namespace pixelBooru_1_.Controllers
{
    public class ArtistController : Controller
    {
        private readonly AppDbContext _dbData;

        public ArtistController(AppDbContext dbData)
        {
            _dbData = dbData;
        }

        public List<string> GetAllUsernames()
        {
            return _dbData.GetAllUsernames();
        }
        public IActionResult Index()
        {
            var usernames = _dbData.GetAllUsernames();
            return View(usernames);
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}