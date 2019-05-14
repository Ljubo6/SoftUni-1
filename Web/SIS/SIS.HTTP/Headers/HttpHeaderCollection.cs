using SIS.HTTP.Common;
using SIS.HTTP.Headers.Contracts;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void AddHeader(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, header.Key);
            if (!this.ContainsHeader(header.Key))
            {
                this.headers.Add(header.Key, header);
            }
        }

        public bool ContainsHeader(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            if (!this.ContainsHeader(key))
            {
                return null;
            }

            return this.headers[key];
        }

        public override string ToString()
        {
            var headerString = new StringBuilder();
            foreach (var header in headers.Values)
            {
                headerString.Append(header.ToString());
                headerString.Append(GlobalConstants.HttpNewLine);
            }

            return headerString.ToString().TrimEnd();
        }
    }
}
