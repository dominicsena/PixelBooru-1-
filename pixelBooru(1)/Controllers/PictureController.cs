// Controllers/PictureController.cs
using Microsoft.AspNetCore.Mvc;
using pixelBooru_1_.Models;

public class PictureController : Controller
{
    public IActionResult Index()
    {
        var picture = new PictureModel
        {
            ImageUrl = "/images/sample.jpg",
            Comments = "This is a sample comment."
        };

        return View(picture);
    }

    [HttpPost]
    public IActionResult AddComment(PictureModel model)
    {
        // Process and save the comment, for simplicity, just redisplay the same view
        return View("Index", model);
    }
}
