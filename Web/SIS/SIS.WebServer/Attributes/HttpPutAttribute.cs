namespace SIS.WebServer.Attributes
{
    using SIS.HTTP.Enums;

    public class HttpPutAttribute : BaseHttpAttribute
    {
        public override HttpRequestMethod Method => HttpRequestMethod.Put;
    }
}
