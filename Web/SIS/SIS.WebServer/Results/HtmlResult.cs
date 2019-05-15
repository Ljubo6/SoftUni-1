using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.WebServer.Results
{
    public class HtmlResult : HttpResponse
    {
        public HtmlResult(string content, HttpResponseStatusCode resonseStatusCode) : base(resonseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader("Content-Type", ContentType.Html));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
