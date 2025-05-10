
namespace WebApp.Core.models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; } = default!;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; } = default!;
        public bool IsDeleted { get; set; } = false;

    }
}

