using System.ComponentModel.DataAnnotations;

namespace WebApp.Api.Dtos
{
    public class UpdateUserDto
    {
        public string Id { get; set; }
        public string? Address { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; } = default!;

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = default!;
    }
}
