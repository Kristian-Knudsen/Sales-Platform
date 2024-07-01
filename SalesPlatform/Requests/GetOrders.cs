namespace SalesPlatform.Requests
{
    public class GetOrders
    {
        public Guid id { get; set; } = Guid.Empty;
        public string status { get; set; } = String.Empty;
        public DateTime date { get; set; }
        public decimal amount { get; set; }
        public string customerName { get; set; } = String.Empty;
        public string customerEmail {  get; set; } = String.Empty;
    }
}
