namespace SalesPlatform.Models
{
    public class OrderItem : BaseModel
    {
        public int quantity { get; set; }
        public Guid productId { get; set; } = Guid.Empty;
        public Guid orderId { get; set; } = Guid.Empty;
        public Product product { get; set; } = null!;
        public Order order { get; set; } = null!;
    }
}
