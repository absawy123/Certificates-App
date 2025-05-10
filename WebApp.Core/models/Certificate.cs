using WebApp.Core.enums;

namespace WebApp.Core.models
{
    public class Certificate : BaseEntity
    {
        public DateOnly? ExaminationDate { get; set; }
        public DateOnly? NextExaminationDate { get; set; }
        public DateOnly? DateofLoadTest { get; set; }
        public Guid CertificateNumber { get; set; } = new Guid();
        public short? Quantity { get; set; }
        public int? LoadNumber { get ; set; }
        public string? LoadTestCertificateNumber { get; set; } = "N/A"; 
        public string? DateOfManufacturing { get; set; } = "N/A";

        public string? Material { get; set; } = "N/A";
        public int? ModelNumber { get; set; } 
        public string? Manufacturer { get; set; } = "N/A";
        public string? Length { get; set; } = "N/A";

        // Required 
        public string Status { get; set; } = CertificateStatus.Pending.ToString();
        public string Load { get; set; } = default!;
        public string EvaluationCriteria { get; set; } = default!;

        public string? DefectivePart { get; set; } = "N/A";
        public string? RequiredRepairs { get; set; } = "N/A";

        // boolean 
        public bool IsFirstInspection { get; set; }
        public bool IsInspectedWithin6Months { get; set; }
        public bool IsInspectedWithinLastYear { get; set; }
        public bool IsItemInstalledCorrectly { get; set; }
        public bool IsEquipmentSafe { get; set; }
        public bool IsExaminedPerProtocol { get; set; }
        public bool IsAfterUnusualEvent { get; set; }
        public bool IsDefectRiskToPersons { get; set; }


        // RelationShips
        #region

        public int CertificateTitleId { get; set; }
        public CertificateTitle CertificateTitle { get; set; } = default!;

        public int CertificateTypeId { get; set; }
        public CertificateType CertificateType { get; set; } = default!;

        public int ReferenceId { get; set; }
        public ReferenceStandared ReferenceStandared { get; set; } = default!;

        public int JobId { get; set; }
        public Job Job { get; set; } = default!;

        public int InspectedItemId { get; set; }
        public InspectedItem InspectedItem { get; set; } = default!;



        public int CertificateIssuerId { get; set; }
        public ApplicationUser Inspector { get; set; } = default!;

        public int CertificateAuthenticatorId { get; set; }
        public ApplicationUser Admin { get; set; } = default!;

        #endregion


    }
}


