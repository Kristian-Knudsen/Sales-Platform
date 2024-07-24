namespace SalesPlatform.Models
{
    public class CustomerInteractionMessage : BaseModel
    {
        public string content { get; set; } = String.Empty;
        public User? responder { get; set; }
        public Guid responderId { get; set; } = Guid.Empty;
        public CustomerInteraction interaction { get; set; } = null!;
        public Guid interactionId { get; set; } = Guid.Empty;
    }
}