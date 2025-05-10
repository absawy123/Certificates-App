namespace WebApp.Application.Dtos.certificateType
{
    public class ReadLocationDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;

        public int ClientId { get; set; }  // clientName (UserName)
    }
}
