using Microsoft.AspNetCore.Mvc;
using pixelBooru_1_.Data;
using pixelBooru_1_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;



namespace pixelBooru_1_.Controllers
{
    public class ArtworkController : Controller
    {

        private readonly AppDbContext _dbData;
        private readonly UserManager<users> _userManager;

        public ArtworkController(AppDbContext dbData, UserManager<users> userManager)
        {
            _dbData = dbData;
            _userManager = userManager;
        }



        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(Artwork newArtwork, IFormFile artImg)
        {
            if (!ModelState.IsValid)
                return View();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(artImg != null && artImg.Length > 0)
            {
                using var memoryStream = new  MemoryStream();
                await artImg.CopyToAsync(memoryStream);
                newArtwork.artImg = memoryStream.ToArray();
            }

            _dbData.Artworks.Add(newArtwork);
            _dbData.SaveChanges();
            return RedirectToAction("Profile");
        }

        public IActionResult Profile()
        {
            return View(_dbData.Artworks);
        }
        
        public IActionResult Post()
        {
            return View();
        }


    }
}
