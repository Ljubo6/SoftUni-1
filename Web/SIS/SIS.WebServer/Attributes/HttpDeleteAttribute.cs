namespace SIS.WebServer.Attributes
{
    using SIS.HTTP.Enums;

    public class HttpDeleteAttribute : BaseHttpAttribute
    {
        public override HttpRequestMethod Method => HttpRequestMethod.Delete;
    }
}
