namespace Musaca.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Result;

    public class ReceiptsController : Controller
    {
        public ActionResult All()
        {
            return this.View();
        }
    }
}
