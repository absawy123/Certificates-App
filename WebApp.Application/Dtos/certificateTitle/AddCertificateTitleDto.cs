using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dtos.certificateTitle
{
    public class AddCertificateTitleDto
    {
        [Required(ErrorMessage = "Certificate title is required")]
        [Display(Name ="Certificate Title")]
        public string Description { get; set; } = default!;
    }

}
