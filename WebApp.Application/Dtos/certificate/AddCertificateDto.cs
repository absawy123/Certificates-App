using System.ComponentModel.DataAnnotations;
using WebApp.Core.enums;

namespace WebApp.Application.Dtos.Certificate
{
    public class AddCertificateDto
    {

        [Required(ErrorMessage = "Load is Required")]
        public string Load { get; set; } = default!;


        [Required(ErrorMessage = "EquipmentName is Required")]
        public string EquipmentName { get; set; } = default!;
        [Required]
        public int EquipmentId { get; set; }

        [Required(ErrorMessage = "EvaluationCriteria is Required")]
        public string EvaluationCriteria { get; set; } = default!;


        [Required(ErrorMessage = "Equipment ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid ID.")]
        [Display(Name = "Equipment ID")]
        public int InspectedItemId { get; set; }


        [Display(Name ="Through Examination Date")]
        public DateOnly? ExaminationDate { get; set; }
        public DateOnly DateofLoadTest { get; set; } 
        public short? Quantity { get; set; }
        public int? LoadNumber { get; set; }


        public string? LoadTestCertificateNumber { get; set; }
        public string? DateOfManufacturing { get; set; } 
        public string? Material { get; set; } 
        public int? ModelNumber { get; set; }
        public string? Manufacturer { get; set; }


        public string? Length { get; set; } 
        public CertificateStatus? Status { get; set; } = CertificateStatus.Pending;
        public string? DefectivePart { get; set; }
        public string? RequiredRepairs { get; set; } 

       

        // Foreign Keys 
        #region
       
        public int? CertificateTitleId { get; set; }
        public int? CertificateTypeId { get; set; }
        public int? ReferenceId { get; set; }
        public int? JobId { get; set; }


        public int? CertificateIssuerId { get; set; }
        public int? CertificateAuthenticatorId { get; set; }

        #endregion


        public bool? IsFirstInspection { get; set; }
        public bool? IsInspectedWithin6Months { get; set; }
        public bool? IsInspectedWithinLastYear { get; set; }
        public bool? IsItemInstalledCorrectly { get; set; }
        public bool? IsEquipmentSafe { get; set; }
        public bool? IsExaminedPerProtocol { get; set; }
        public bool? IsAfterUnusualEvent { get; set; }
        public bool? IsDefectRiskToPersons { get; set; }
    }

}


