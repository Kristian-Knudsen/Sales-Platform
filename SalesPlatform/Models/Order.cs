namespace SalesPlatform.Models
{
    public class Order : BaseModel
    {
        public decimal totalPrice { get; set; }
        public string status { get; set; } = string.Empty;
        public Guid customerId { get; set; } = Guid.Empty;
        public Guid storeId { get; set; } = Guid.Empty;
        public Customer customer { get; set; } = null!;
        public Store store { get; set; } = null!;
        public ICollection<OrderItem> orderItems  { get; set; } = null!;
    }
}
