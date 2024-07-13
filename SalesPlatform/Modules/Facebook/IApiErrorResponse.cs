namespace SalesPlatform.Modules.Facebook
{
    public interface IApiErrorResponse
    {
        IApiErrorResponseContent error { get; }
    }
}