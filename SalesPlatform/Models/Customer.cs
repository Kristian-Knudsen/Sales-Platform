namespace SalesPlatform.Models
{
    public class Customer : BaseModel
    {
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public Guid shippingDetailsId { get; set; } = Guid.Empty;
        public ShippingDetails? shippingDetails { get; set; } = null!;
        public ICollection<Order>? orders { get; set; } = null!;
    }
}
