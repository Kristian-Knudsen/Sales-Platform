namespace SalesPlatform.Models
{
    public enum CustomerInteractionStatusses
    {
        Open,
        Closed,
        OnHold,
        Taken
    }
    public class CustomerInteractionStatus : BaseModel
    {
        public CustomerInteractionStatusses value { get; set; }
        public bool isActive { get; set; }
    }
}