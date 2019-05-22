namespace SIS.HTTP.Requests
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Cookies.Contracts;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Exceptions;
    using SIS.HTTP.Extentions;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Headers.Contracts;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Sessions.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public IHttpCookieCollection Cookies { get; }

        public IHttpSession Session { get; set; }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestLines = requestString.Split(GlobalConstants.HttpNewLine, StringSplitOptions.None);
            string[] requestLineArgs = splitRequestLines[0].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsvalidRequestLine(requestLineArgs))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLineArgs);
            this.ParseRequestUrl(requestLineArgs);
            this.ParseRequestPath();

            this.ParseRequestHeaders(splitRequestLines.Skip(1).ToArray());
            this.ParseCookies();

            this.ParseQueryParameters();
            this.ParseRequestFormDataParameters(splitRequestLines.Last());
        }

        private void ParseCookies()
        {
            if (this.Headers.ContainsHeader("Cookie"))
            {
                string cookieHeaderString = this.Headers.GetHeader("Cookie").Value;
                string[] unparsedCookies = cookieHeaderString.Split("; ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var cookie in unparsedCookies)
                {
                    var cookieElements = cookie.Split('=');
                    var key = cookieElements[0];
                    var value = cookieElements[1];
                    var newCookie = new HttpCookie(key, value, false);
                    this.Cookies.AddCookie(newCookie);
                }
            }
        }

        private void ParseRequestFormDataParameters(string requestBody)
        {
            if (!string.IsNullOrEmpty(requestBody))
            {
                var unparsedQueries = requestBody.Split("&", StringSplitOptions.RemoveEmptyEntries);

                foreach (var query in unparsedQueries)
                {
                    var queryArgs = query.Split('=');
                    this.FormData.Add(queryArgs[0], queryArgs[1]);
                }
            }
        }

        private void ParseRequestHeaders(string[] unparsedHeaders)
        {
            foreach (var headerLine in unparsedHeaders)
            {
                if(headerLine == string.Empty)
                {
                    return;
                }

                var headerArgs = headerLine.Split(": ");
                var header = new HttpHeader(headerArgs[0], headerArgs[1]);
                this.Headers.AddHeader(header);

                if (!this.Headers.ContainsHeader(GlobalConstants.HostHeaderKey))
                {
                    throw new BadRequestException();
                }
            }
        }

        private void ParseRequestPath()
        {
            this.Path = this.Url.Split("?").First();
        }

        private void ParseRequestUrl(string[] requestLineArgs)
        {
            this.Url = requestLineArgs[1];
        }

        private void ParseRequestMethod(string[] requestLineArgs)
        {
            HttpRequestMethod requestMethod;
            var isParsed = Enum.TryParse<HttpRequestMethod>(requestLineArgs[0].Capitalize(), out requestMethod);
            if (isParsed)
            {
                this.RequestMethod = requestMethod;
            }
        }

        private void ParseQueryParameters()
        {
            if (!this.Url.Contains('?'))
            {
                return;
            }

            var queryString = this.Url.Split('?', '#')[1];

            if (!this.IsValidRequestQueryString(queryString))
            {
                throw new BadRequestException();
            }

            queryString
                .Split('&')
                .Select(queryParam => queryParam.Split('='))
                .ToList()
                .ForEach(kvp => this.QueryData.Add(kvp[0], kvp[1]));
        }

        private bool IsValidRequestQueryString(string queryString)
        {
            var isNotEmpty = string.IsNullOrEmpty(queryString) == false;
            var hasParameters = queryString.Split('&').Count() > 0;

            return isNotEmpty && hasParameters;
        }

        private bool IsvalidRequestLine(string[] requestLineArgs)
        {
            return requestLineArgs.Length == 3 && requestLineArgs.Last() == GlobalConstants.HttpOneProtocolFragment;
        }
    }
}
