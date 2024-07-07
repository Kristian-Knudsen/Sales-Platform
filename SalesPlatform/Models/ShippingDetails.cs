namespace SalesPlatform.Models
{
    public class ShippingDetailsSimple
    {
        public string address { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
        public string zipCode { get; set; } = string.Empty;
    }
    public class ShippingDetails : BaseModel
    {
        public string address { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
        public string zipCode { get; set; } = string.Empty;
        public Guid? customerId { get; set; } = null!;
        public Customer? customer { get; set; } = null!;

        public virtual ShippingDetailsSimple GetSimpleShippingDetails()
        {
            return new ShippingDetailsSimple()
            {
                address = address,
                city = city,
                country = country,
                state = state,
                zipCode = zipCode
            };
        }
    }
}
