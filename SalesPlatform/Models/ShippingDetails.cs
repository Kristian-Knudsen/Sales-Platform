namespace SalesPlatform.Models
{
    public class ShippingDetails : BaseModel
    {
        public string address { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
        public string zipCode { get; set; } = string.Empty;
        public Guid? customerId { get; set; } = null!;
        public Customer? customer { get; set; } = null!;
    }
}
