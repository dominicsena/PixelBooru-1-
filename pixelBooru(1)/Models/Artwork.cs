using pixelBooru_1_.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace pixelBooru_1_.Models
{

    public enum Rating
    {
        All, R15, R18
    }


        
    public class Artwork
    {
        [Key]
        public int artId { get; set; }
        [ForeignKey("userId")]

        public string? UserId { get; set; }

        public string? UID { get; set; }

        public string? artTitle { get; set; }

        public string? artCaption {  get; set; }

        [DataType(DataType.Upload)]
        [RegularExpression(@"^.*\.(jpg|jpeg|png)$", ErrorMessage = "Only JPG, JPEG, and PNG files are allowed.")]
        public byte[]? artImg { get; set;}

        public string? artTags { get; set;}

        public Rating artRating { get; set;}


    }
}
