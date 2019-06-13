namespace Musaca.App.Controllers
{
    using Musaca.Models.Enums;
    using Musaca.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;

    public class OrdersController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public OrdersController(IProductService productService, IOrderService orderService)
        {
            this.productService = productService;
            this.orderService = orderService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddProduct(string product)
        {
            var productFromDb = this.productService.GetProductByName(product);
            this.orderService.AddProductToCurrentActiveOrder(this.User.Id, productFromDb.Id);
            return this.Redirect("/Home/Index");
        }

        public IActionResult Cashout()
        {
            var currentOrder = this.orderService.GetActiveOrderByUserId(this.User.Id);
            this.orderService.CompleteOrder(currentOrder.Id);
            this.orderService.CreateActiveOrder(this.User.Id);
            return this.Redirect("/");
        }
    }
}
