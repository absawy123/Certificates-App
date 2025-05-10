using Microsoft.AspNetCore.Identity;

namespace WebApp.Core.models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? Address { get; set; } = default!;
        public bool IsDeleted { get; set; } = false;
        public ICollection<Location>? Locations { get; set; }
        public ICollection<Certificate>? Certificates { get; set; }

    }
}
