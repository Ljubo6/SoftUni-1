namespace SIS.HTTP.Cookies
{
    using Contracts;
    using SIS.HTTP.Common;
    using System.Collections;
    using System.Collections.Generic;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly Dictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void AddCookie(HttpCookie cookie)
        {
            CoreValidator.ThrowIfNull(cookie, nameof(cookie));

            if (!this.ContainsCookie(cookie.Key))
            {
                this.cookies.Add(cookie.Key, cookie);
            }
        }

        public bool ContainsCookie(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            return this.cookies.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            if (!this.ContainsCookie(key))
            {
                return null;
            }

            return this.cookies[key];
        }

        public IEnumerator<HttpCookie> GetEnumerator()
        {
            foreach (var cookieKvp in this.cookies)
            {
                yield return cookieKvp.Value;
            }
        }

        public bool HasCookies()
        {
            return this.cookies.Count > 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join("; ", this.cookies.Values);
        }
    }
}
