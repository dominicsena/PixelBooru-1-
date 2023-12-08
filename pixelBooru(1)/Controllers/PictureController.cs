// Controllers/PictureController.cs
using Microsoft.AspNetCore.Mvc;
using pixelBooru_1_.Models;

public class PictureController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        // Initialize PictureModel and retrieve user information from session
        var model = new PictureModel
        {
            /*Username = HttpContext.Session.GetString("Username"),
            ProfilePictureUrl = HttpContext.Session.GetString("ProfilePictureUrl")*/
            Username = "GuestUser",
            ProfilePictureUrl = "~/testImages/ff.jpg"

        };

        return View(model);
    }

    [HttpPost]
    public IActionResult AddComment(PictureModel model)
    {
        if (!string.IsNullOrEmpty(model.Comment))
        {
            // Add the new comment to the Comments list
            var commentsList = model.Comments.ToList();
            commentsList.Add(model.Comment);
            model.Comments = commentsList.ToArray();

            // Clear the Comment property after adding it to the list
            model.Comment = null;
        }

        // Retrieve user information from session and update the model
        /*model.Username = HttpContext.Session.GetString("Username");
        model.ProfilePictureUrl = HttpContext.Session.GetString("ProfilePictureUrl");*/

        model.Username = "GuestUser";
        model.ProfilePictureUrl = "~/testImages/ff.jpg";

        // Return to the Index view with the updated model
        return View("Index", model);
    }
}
