namespace Musaca.App.Controllers
{
    using Musaca.App.ViewModels;
    using Musaca.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Mapping;
    using SIS.MvcFramework.Result;

    public class HomeController : Controller
    {
        private readonly IOrderService orderService;

        public HomeController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpGet(Url = "/")]
        public ActionResult IndexSlash()
        {
            return Index();
        }

        public ActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                var activeOrdersViewModel = new ActiveOrdersHomeViewModel();
                var allActiveOrdersFromDb = this.orderService.GetAllActiveOrders();

                foreach (var order in allActiveOrdersFromDb)
                {
                    var activeOrder = ModelMapper.ProjectTo<ActiveOrderViewModel>(order);
                    activeOrder.Name = order.Product.Name;
                    activeOrder.Price = order.Product.Price;
                    activeOrdersViewModel.Add(activeOrder);
                }

                return this.View(activeOrdersViewModel);
            }

            return this.View();
        }

        [HttpPost]
        public ActionResult Index(long barcode, int quantity)
        {
            var newOrder = this.orderService.GenerateOrder(barcode, quantity);
            this.orderService.AddOrder(newOrder);
            return this.Redirect("/");
        }
    }
}
