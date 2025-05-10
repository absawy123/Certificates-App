using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dtos.referenceStandared
{
    public class UpdateReferenceDto
    {
        [Required(ErrorMessage ="Reference Id is required")]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = default!;

    }

}
