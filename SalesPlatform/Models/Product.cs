namespace SalesPlatform.Models
{
    public class Product : BaseModel
    {
        public string name { get; set; } = String.Empty;
        public string description { get; set; } = String.Empty;
        public decimal price { get; set; }
        public bool isDraft { get; set; }
        public int stock { get; set; }
        public Guid storeId { get; set; }
        public Store store { get; set; } = null!;
    }
}
