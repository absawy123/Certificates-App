using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dtos.certtificateType
{
    public class UpdateCerTypeDto
    {
        [Required(ErrorMessage = "CertificateType ID is required.")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = default!;
    }

}
