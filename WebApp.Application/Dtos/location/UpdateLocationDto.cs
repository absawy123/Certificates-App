using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dtos.certificateType
{
    public class UpdateLocationDto
    {
        [Required(ErrorMessage ="Location Id is required")]
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;

        public int ClientId { get; set; }
    }
}
