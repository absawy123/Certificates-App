using System.ComponentModel.DataAnnotations;
using WebApp.Core.enums;

namespace WebApp.Application.Dtos.Certificate
{
    public class UpdateCertificateDto
    {
        [Required(ErrorMessage = "Certificate ID is required.")]
        public int Id { get; set; }

        [Required]
        public DateOnly ExaminationDate { get; set; }

        [Required]
        public DateOnly NextExaminationDate { get; set; }

        [Required]
        public DateOnly DateofLoadTest { get; set; }

        [Required]
        public short Quantity { get; set; }

        [Required]
        public int LoadNumber { get; set; }

        [Required(ErrorMessage = "Load Test Certificate Number is required.")]
        public string LoadTestCertificateNumber { get; set; } = default!;

        [Required]
        public string DateOfManufacturing { get; set; } = default!;

        [Required]
        public string Material { get; set; } = default!;

        [Required]
        public int ModelNumber { get; set; }

        [Required]
        public string Manufacturer { get; set; } = default!;

        [Required]
        public string Length { get; set; } = default!;

        [Required]
        public CertificateStatus Status { get; set; }

        [Required]
        public string LoadUnit { get; set; } = default!;

        [Required]
        public string DefectivePart { get; set; } = default!;

        [Required]
        public string RequiredRepairs { get; set; } = default!;

        [Required]
        public string EvaluationCriteria { get; set; } = default!;

        // Foreign Keys 
        public int CertificateTitleId { get; set; }
        public int CertificateTypeId { get; set; }
        public int ReferenceId { get; set; }
        public int JobId { get; set; }
        public int InspectedItemId { get; set; }
        public int CertificateIssuerId { get; set; }
        public int CertificateAuthenticatorId { get; set; }

        public bool IsFirstInspection { get; set; }
        public bool IsInspectedWithin6Months { get; set; }
        public bool IsInspectedWithinLastYear { get; set; }
        public bool IsItemInstalledCorrectly { get; set; }
        public bool IsEquipmentSafe { get; set; }
        public bool IsExaminedPerProtocol { get; set; }
        public bool IsAfterUnusualEvent { get; set; }
        public bool IsDefectRiskToPersons { get; set; }
    }

}



