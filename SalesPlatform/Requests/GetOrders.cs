using SalesPlatform.Models;

namespace SalesPlatform.Requests
{
    public class GetOrders
    {
        public Guid id { get; set; } = Guid.Empty;
        public OrderStatus status { get; set; } = OrderStatus.AwaitingStatus;
        public DateTime date { get; set; }
        public decimal amount { get; set; }
        public string customerName { get; set; } = String.Empty;
        public string customerEmail {  get; set; } = String.Empty;
    }
}
