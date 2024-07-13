namespace SalesPlatform.Models
{
    public enum CustomerInteractionChannels
    {
        Messenger,
        Instagram,
        Sms,
        Phonecall,
        Email,
        Linkedin
    }
    public class CustomerInteractionChannel : BaseModel
    {
        public CustomerInteractionChannels value { get; set; }
        public bool isActive { get; set; }
    }
}