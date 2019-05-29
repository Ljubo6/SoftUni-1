namespace IRunes.App.Controllers
{
    using IRunes.Models;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;

    public class BaseController
    {
        protected Dictionary<string, object> ViewData;

        protected BaseController()
        {
            this.ViewData = new Dictionary<string, object>();
        }

        protected bool IsLoggedIn(IHttpRequest httpRequest)
        {
            return httpRequest.Session.ContainsParameter("username");
        }

        protected string ParseTemplate(string viewContent)
        {
            foreach (var param in this.ViewData)
            {
                viewContent = viewContent.Replace($"@Model.{param.Key}", param.Value.ToString());
            }
            return viewContent;
        }
        public IHttpResponse View([CallerMemberName] string view = null)
        {
            string controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            string viewName = view;
            string viewContent = File.ReadAllText($"..\\..\\..\\Views\\{controllerName}\\{viewName}.html");
            viewContent = this.ParseTemplate(viewContent);

            return new HtmlResult(viewContent, HttpResponseStatusCode.Ok);
        }

        public IHttpResponse Redirect(string url)
        {
            return new RedirectResult(url);
        }

        protected void SignIn(IHttpRequest httpRequest, User user)
        {
            httpRequest.Session.AddParameter("id", user.Id);
            httpRequest.Session.AddParameter("username", user.Username);
            httpRequest.Session.AddParameter("email", user.Email);
        }

        protected void SignOut(IHttpRequest httpRequest)
        {
            httpRequest.Session.ClearParameters();
        }
    }
}
