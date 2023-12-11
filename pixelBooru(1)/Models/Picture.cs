using System.Collections.Generic;

namespace pixelBooru_1_.Models
{
    // Models/PictureModel.cs
    public class PictureModel
    {
        public string ImageUrl { get; set; }

        public string[] Comments { get; set; } = new string[0];  // Initialize as an empty array

        public string Comment { get; set; }

        // New properties for username and profile picture URL
        public string Username { get; set; } 
        public string ProfilePictureUrl { get; set; } 

        // Other methods or properties...
    }
}