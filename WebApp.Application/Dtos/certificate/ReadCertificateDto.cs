using WebApp.Core.enums;

namespace WebApp.Application.Dtos.Certificate
{
    public class ReadCertificateDto
    {
        public DateOnly ExaminationDate { get; set; }
        public DateOnly NextExaminationDate { get; set; }
        public DateOnly DateofLoadTest { get; set; }
        public short Quantity { get; set; }
        public int LoadNumber { get; set; }
        public Guid CertificateNumber { get; set; }

        public string LoadTestCertificateNumber { get; set; } = default!;
        public string DateOfManufacturing { get; set; } = default!;
        public string Material { get; set; } = default!;
        public int ModelNumber { get; set; }
        public string Manufacturer { get; set; } = default!;

        public string Length { get; set; } = default!;
        public CertificateStatus Status { get; set; }
        public string LoadUnit { get; set; } = default!;

        public string DefectivePart { get; set; } = default!;
        public string RequiredRepairs { get; set; } = default!;
        public string EvaluationCriteria { get; set; } = default!;

        // Foreign Keys 
        #region
        public int CertificateTitleId { get; set; } // Description
        public int CertificateTypeId { get; set; } // CertificateName 
        public int ReferenceId { get; set; }  // ReferenceTitle
        public int JobId { get; set; } // JobNumber (Guid)
        public int InspectedItemId { get; set; } // InspectedItemName

        // ask eng keep this or remove 
        public int CertificateIssuerId { get; set; } 
        public int CertificateAuthenticatorId { get; set; }

        #endregion

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
