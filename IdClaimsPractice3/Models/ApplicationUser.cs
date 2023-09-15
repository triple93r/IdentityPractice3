using Microsoft.AspNetCore.Identity;

namespace IdClaimsPractice3.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = null!;
    }
}
