namespace WebApp.Core.models
{
    public class Job : BaseEntity
    {
        public Guid JobNumber { get; set; }
        public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

        public int LocationId { get; set; }
        public Location Location { get; set; } = default!;
    }
}
