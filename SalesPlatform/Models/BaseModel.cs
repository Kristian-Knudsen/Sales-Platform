
namespace SalesPlatform.Models
{
    public class BaseModel
    {
        public Guid id { get; set; } = Guid.NewGuid();

        public DateTime createdAt { get; set; } = DateTime.UtcNow;

        public DateTime? updatedAt { get; set; }
    }
}
