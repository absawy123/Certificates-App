using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dtos.certificateType
{
    public class AddJobDto
    {
        [Required(ErrorMessage ="Name is Required.")]
        public string Name { get; set; } = default!;
        [Required(ErrorMessage = "Description is Required.")]
        public string Description { get; set; } = default!;

        [Required(ErrorMessage = "PhoneNumber is Required.")]
        public string PhoneNumber { get; set; } = default!;

        [Required(ErrorMessage = "Client Id is Required.")]
        public int ClientId { get; set; }
    }
}
