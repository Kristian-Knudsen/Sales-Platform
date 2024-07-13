using Newtonsoft.Json;

namespace SalesPlatform.Modules.Facebook
{
    public class IApiSuccesResponse
    {
        [JsonProperty]
        public List<IConversation> data { get; set; }
        [JsonProperty]
        public IPaging? paging { get; set; }
    }

    public class IPaging
    {
        [JsonProperty]
        public ICursors cursors { get; set; }
    }

    public class ICursors
    {
        [JsonProperty]
        public string before { get; set; }
        [JsonProperty]
        public string after { get; set; }
    }

    public class IConversation
    {
        [JsonProperty]
        public string id { get; set; }
        [JsonProperty]
        public IParticipant participants { get; set; }
        [JsonProperty]
        public IMessage messages { get; set; }
    }

    public class IMessage
    {
        [JsonProperty]
        public List<IInnerMessage> data { get; set; }
        [JsonProperty]
        public IPaging paging { get; set; }
    }

    public class IInnerMessage
    {
        [JsonProperty]
        public string id { get; set; }
        [JsonProperty]
        public string message { get; set; }
    }

    public class IParticipant
    {
        public List<IInnerParticipant> data { get; set; }
    }

    public class IInnerParticipant
    {
        [JsonProperty]
        public string name { get; set; }
        [JsonProperty]
        public string email { get; set; }
        [JsonProperty]
        public string id { get; set; }
    }
}

