namespace SIS.WebServer.Results
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Responses;

    public class InlineResourceResult : HttpResponse
    {
        public InlineResourceResult(byte[] content, HttpResponseStatusCode responseStatusCode) : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader("ContentLength", content.Length.ToString()));
            this.Headers.AddHeader(new HttpHeader("Content-Disposition", "inline"));
            this.Content = content;
        }
    }
}
