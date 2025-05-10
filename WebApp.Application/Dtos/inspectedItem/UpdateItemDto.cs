using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dtos.certificateType
{
    public class UpdateItemDto
    {
        [Required(ErrorMessage ="Inspected Item id is required")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = default!;
    }
}
