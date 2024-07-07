using SalesPlatform.Models;

namespace SalesPlatform.Requests
{
    public class GetOrders
    {
        public Guid id { get; set; } = Guid.Empty;
        public OrderStatus status { get; set; } = OrderStatus.AwaitingStatus;
        public DateTime createdAt { get; set; }
        public decimal totalPrice { get; set; }
        public string fullName { get; set; } = String.Empty;
        public string email {  get; set; } = String.Empty;
    }
}
