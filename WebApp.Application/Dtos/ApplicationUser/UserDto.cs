using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dtos.ApplicationUser
{
    public class UserDto
    {

        public string? Address { get; set; }

        [Required(ErrorMessage ="UserName is required")]
        public string UserName { get; set; } = default!;

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8)]
        public string Password { get; set; } = default!;

    }
}
