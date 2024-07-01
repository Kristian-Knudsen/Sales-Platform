namespace SalesPlatform.Models
{
    public class Store : BaseModel
    {
        public string name { get; set; } = String.Empty;
        public ICollection<User> employees { get; set; } = new List<User>();
        public ICollection<Product> products { get; set; } = new List<Product>();
    }
}
