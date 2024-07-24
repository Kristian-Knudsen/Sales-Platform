namespace SalesPlatform.Modules.Facebook
{
    public interface IApiErrorResponseContent
    {
        string message { get; }
        string type { get; }
        int code { get; }
        string fbtrace_id { get; }
    }
}