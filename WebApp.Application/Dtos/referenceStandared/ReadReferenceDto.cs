using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dtos.referenceStandared
{
    public class ReadReferenceDto
    {
        [Required]
        public string Title { get; set; } = default!;

    }

}
