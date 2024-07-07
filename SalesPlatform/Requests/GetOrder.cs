using SalesPlatform.Models;

namespace SalesPlatform.Requests
{
    public class ItemDetails
    {
        public string name { get; set; } = String.Empty;
        public int quantity { get; set; }
        public decimal price { get; set; }
    }
    public class GetOrder
    {
        public Guid id { get; set; } = Guid.Empty;
        public DateTime createdAt { get; set; }
        public IEnumerable<ItemDetails> items { get; set; }
        public decimal totalPrice { get; set; }
        public decimal tax { get; set; }
        public decimal shippingFee { get; set; }
        public ShippingDetailsSimple? shippingDetails { get; set; }
        public string customerFullName { get; set; } = String.Empty;
        public string customerEmail {  get; set; } = String.Empty;
        public string customerPhoneNumber { get; set; } = String.Empty;
        public string paymentInformation { get; set; } = String.Empty;
    }
}