using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dtos.certificateType
{
    public class AddLocationDto
    {
        [Required(ErrorMessage ="Location Name is required")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Location Description is required")]
        public string Description { get; set; } = default!;
        [Required(ErrorMessage = "Location PhoneNumber is required")]
        public string PhoneNumber { get; set; } = default!;

        [Required]
        public int ClientId { get; set; }
    }
}
