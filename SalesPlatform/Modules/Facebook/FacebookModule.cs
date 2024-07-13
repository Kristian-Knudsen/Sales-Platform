using NuGet.Protocol;
using System.Net;

namespace SalesPlatform.Modules.Facebook
{
    public class FacebookModuleReturnObject
    {
        public FacebookModuleReturnObject(bool isSuccess, object data)
        {
            this.isSuccess = isSuccess;
            this.data = data;
        }

        public object? data { get; set; }
        public bool isSuccess { get; set; }
    }
    public class FacebookModule
    {
        static HttpClient client = new();
        readonly string FacebookClientUrl = "https://graph.facebook.com/v20.0/";
        readonly string pageId = DotNetEnv.Env.GetString("FACEBOOK_PAGE_ID");
        readonly string pageToken = DotNetEnv.Env.GetString("FACEBOOK_PAGE_ACCESS_TOKEN");
        
        public async Task<object> getPageConversations() {
            const string fields = "fields=participants,messages{id,message}";
            string remainingUrl = $"{pageId}/conversations?{fields}&access_token={pageToken}";
            
            HttpResponseMessage response = await client.GetAsync(FacebookClientUrl + remainingUrl);

            return await response.Content.ReadFromJsonAsync<IApiSuccesResponse>();
        }

        public async Task<object> getConversationById(string conversationId)
        {
            const string fields = "fields=messages{id,message,from}";
            string remainingUrl = $"{conversationId}/messages?{fields}";

            HttpResponseMessage response = await client.GetAsync(FacebookClientUrl + remainingUrl);

            return await response.Content.ReadAsStreamAsync();
        }
    }
}   