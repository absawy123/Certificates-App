namespace WebApp.Core.models
{
    public class Location : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;

        public int ClientId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; } = default!;
        public ICollection<Job>? Jobs { get; set; } = new List<Job>();


    }
}
