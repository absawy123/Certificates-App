using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Core.models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
