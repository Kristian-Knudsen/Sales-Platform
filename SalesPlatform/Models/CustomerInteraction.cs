namespace SalesPlatform.Models
{
    public class CustomerInteraction : BaseModel
    {
        public ICollection<CustomerInteractionMessage>? interactions { get; set; }
        public Customer? customer { get; set; }
        public Guid customerId { get; set; } = Guid.Empty;
        public CustomerInteractionStatus status { get; set; } = null!;
        public Guid customerInteractionStatusId { get; set; }
        public CustomerInteractionChannel channel { get; set; } = null!;
        public Guid customerInteractionChannelId { get; set; }
    }
}