namespace SIS.Controllers
{
    using HTTP.Requests.Contracts;
    using HTTP.Responses.Contracts;

    public class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest httpRequest)
        {
            return this.View("Index");
        }
    }
}
