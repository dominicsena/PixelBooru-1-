using Microsoft.AspNetCore.Identity;

namespace pixelBooru_1_.Data
{
    public class users : IdentityUser
    {

        public string? firstName { get; set; }
        public string? lastName { get; set; }

    }
}
