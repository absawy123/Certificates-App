namespace WebApp.Core.models
{
    public class InspectedItem : BaseEntity
    {
        public string Name { get; set; } = default!;
        public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
    }
}
