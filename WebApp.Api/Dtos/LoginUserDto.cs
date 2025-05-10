using System.ComponentModel.DataAnnotations;

namespace WebApp.Api.Dtos
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; } = default!;

        public bool RememberMe { get; set; }

    }
}
