using Microsoft.AspNetCore.Mvc;
using pixelBooru_1_.Data;
using pixelBooru_1_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;



namespace pixelBooru_1_.Controllers
{
    public class ArtworkController : Controller
    {

        private readonly AppDbContext _dbData;
        private readonly UserManager<users> _userManager;
        private readonly string[] _extensions = { ".png", ".jpeg", ".jpg" };

        public ArtworkController(AppDbContext dbData, UserManager<users> userManager)
        {
            _dbData = dbData;
            _userManager = userManager;
        }

        protected  ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);

                if (file.Length > 0 && !_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Allowed file types are: {string.Join(", ", _extensions)}";
        }


        public IActionResult Index()
        {
            return View();
        }
       public IActionResult Profile()
        {
            return View( _dbData.Artworks);
        }
     
        [Authorize]
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(Artwork newArtwork, IFormFile? artImg)
        {
            if (!ModelState.IsValid)
                return View();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
           newArtwork.UserId = userId;
              
            

            if(artImg != null && artImg.Length > 0)
            {
                using var memoryStream = new  MemoryStream();
                await artImg.CopyToAsync(memoryStream);
                newArtwork.artImg = memoryStream.ToArray();
            }
            
            _dbData.Artworks.Add(newArtwork);
           await  _dbData.SaveChangesAsync();
            return RedirectToAction("Profile");
        }

        [HttpGet]
        public IActionResult UpdateArtwork(int id)
        {
            //Search for recipe whose id matches the given id
            Artwork? artwork = _dbData.Artworks.FirstOrDefault(rec => rec.artId == id);

            if (artwork != null)
                return View(artwork);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateArtwork(Artwork artworkChanges, IFormFile? changeImg)
        {
            if (ModelState.IsValid)
            {
                Artwork? artwork = _dbData.Artworks.FirstOrDefault(rec => rec.artId == artworkChanges.artId);

                if (artwork != null)
                {
                    artwork.artTitle = artworkChanges.artTitle;
                    artwork.artCaption = artworkChanges.artCaption;
                    artwork.artRating = artworkChanges.artRating;
                    artwork.artTags = artworkChanges.artTags;


                    if (changeImg != null && changeImg.Length > 0)
                    {
                        using MemoryStream memoryStream = new MemoryStream();
                        await changeImg.CopyToAsync(memoryStream);
                        artwork.artImg = memoryStream.ToArray();
                    }
                    else
                    {
                        artwork.artImg = null;
                    }

                    _dbData.Entry(artwork).State = EntityState.Modified;
                    
                    await _dbData.SaveChangesAsync();

                    return RedirectToAction("Profile");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return View("UpdateArtwork", artworkChanges);
            }
        }

     

        [HttpPost]
        public IActionResult DeleteArtwork(int artId)
        {
            // Retrieve the artwork from the database based on the artworkId
            var artwork = _dbData.Artworks.Find(artId);

            if (artwork != null)
            {
                // Remove the artwork from the database
                _dbData.Artworks.Remove(artwork);
                 _dbData.SaveChangesAsync();
            }

            // Redirect to the profile or another appropriate page
            return RedirectToAction("Profile");
        }

      

        

    }
}
