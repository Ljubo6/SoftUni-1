namespace Torshia.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Result;

    public class HomeController : Controller
    {
        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return Index();
        }

        public IActionResult Index()
        {
            if (this.IsLoggedIn() && this.User.Roles.Contains("Admin"))
            {
                return this.View("AdminIndex");
            }
            return this.View();
        }
    }
}
