namespace Musaca.App.Controllers
{
    using Musaca.App.ViewModels;
    using Musaca.Models.Enums;
    using Musaca.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Result;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly IOrderService orderService;

        public HomeController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return Index();
        }

        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                var products = this.orderService.GetAllProductsInActiveOrder(this.User.Id);
                var viewModel = new OrderViewModel();
                foreach (var product in products)
                {
                    var productViewModel = new ProductViewModel
                    {
                        Name = product.Product.Name,
                        Price = product.Product.Price
                    };

                    viewModel.Products.Add(productViewModel);
                }
                return this.View(viewModel, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}
