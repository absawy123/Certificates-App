namespace WebApp.Core.models
{
    public class ReferenceStandared :BaseEntity
    {
        public string Title { get; set; } = default!;

        public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
    }
}
