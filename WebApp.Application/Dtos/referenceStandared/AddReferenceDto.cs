using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dtos.referenceStandared
{
    public class AddReferenceDto
    {
        [Required]
        public string Title { get; set; } = default!;

    }

}
