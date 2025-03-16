using Microsoft.AspNetCore.Identity;

namespace WebApp.Core.models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string UserName { get; set; }
        public ICollection<Location>? Locations { get; set; }

    }
}
