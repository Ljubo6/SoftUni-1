namespace SIS.HTTP.Sessions
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Sessions.Contracts;
    using System.Collections.Generic;

    public class HttpSession : IHttpSession
    {
        private Dictionary<string, object> parameters;

        public HttpSession(string id)
        {
            CoreValidator.ThrowIfNullOrEmpty(id, nameof(id));
            this.Id = id;
            this.parameters = new Dictionary<string, object>();
        }
        public string Id { get; }

        public void AddParameter(string name, object parameter)
        {
            if (!this.ContainsParameter(name))
            {
                this.parameters.Add(name, parameter);
            }
        }

        public void ClearParameters()
        {
            this.parameters.Clear();
        }

        public bool ContainsParameter(string name)
        {
            return this.parameters.ContainsKey(name);
        }

        public object GetParameter(string name)
        {
            if (!this.ContainsParameter(name))
            {
                return null;
            }
            return this.parameters[name];
        }
    }
}
