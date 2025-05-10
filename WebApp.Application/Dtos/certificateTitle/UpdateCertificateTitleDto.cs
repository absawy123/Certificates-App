using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dtos.certificateTitle
{
    public class UpdateCertificateTitleDto
    {
        [Required(ErrorMessage ="Certificate title id is required")]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; } = default!;
    }

}
