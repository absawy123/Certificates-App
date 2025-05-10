namespace WebApp.Core.models
{
    public class CertificateTitle : BaseEntity
    {
        public string Description { get; set; } = default!;
        public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    }
}
