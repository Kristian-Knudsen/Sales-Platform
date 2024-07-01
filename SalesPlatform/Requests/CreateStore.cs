namespace SalesPlatform.Requests
{
    public class CreateStore
    {
        public string name { get; set; } = String.Empty;
        public Guid userId { get; set; }
    }
}
