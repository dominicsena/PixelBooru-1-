using Microsoft.AspNetCore.Identity;

namespace pixelBooru_1_.Data
{
    public class users : IdentityUser
    {

     

        public byte[]? profilePicture { get; set; }

    }
}
