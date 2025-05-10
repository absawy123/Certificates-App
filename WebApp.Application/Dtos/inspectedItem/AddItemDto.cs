using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dtos.certificateType
{
    public class AddItemDto
    {
        [Required(ErrorMessage ="Inspected Item name is required")]
        public string Name { get; set; } = default!;
    }
}
