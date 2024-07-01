namespace SalesPlatform.Models
{
    public class User : BaseModel
    {
        public string email { get; set; } = String.Empty;
        public string password { get; set; } = String.Empty;
        public bool isOwner { get; set; }
        public Guid? storeId { get; set; }
        public Store? store { get; set; }
    }

}
