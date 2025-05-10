using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dtos.certtificateType
{
    public class AddCerTypeDto
    {
        [Required(ErrorMessage ="Certificate type is Required")]
        [Display(Name ="Certificate type")]
        public string Name { get; set; } = default!;
    }

}
