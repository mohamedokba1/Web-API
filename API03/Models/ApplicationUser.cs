using Microsoft.AspNetCore.Identity;

namespace API03.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FavouriteColor { get; set; } = string.Empty;
    }
}
