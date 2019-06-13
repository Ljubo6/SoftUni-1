namespace Musaca.App.Controllers
{
    using Musaca.App.InputModels;
    using Musaca.App.ViewModels;
    using Musaca.Models;
    using Musaca.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly IOrderService orderService;

        public UsersController(IUserService userService, IOrderService orderService)
        {
            this.userService = userService;
            this.orderService = orderService;
        }

        public ActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            User userFromDb = this.userService.GetUserByUsernameAndPassword(username, password);

            if (userFromDb == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userFromDb.Id, userFromDb.Username, userFromDb.Email);

            return this.Redirect("/");
        }

        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Register(UsersRegisterInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            this.userService.AddNewUserToDb(inputModel.Username, inputModel.Password, inputModel.Email);

            return this.Redirect("/Users/Login");
        }

        [Authorize]
        public IActionResult Profile()
        {
            var completedOrders = this.orderService.GetCompletedOrdersByUserId(this.User.Id);

            var viewModel = completedOrders.Select(o => new ProfileOrderViewModel
            {
                Id = o.Id,
                Total = o.Products.Sum(p => p.Product.Price),
                IssuedOn = o.IssuedOn.ToString("dd/MM/yyyy"),
                CashierName = o.Cashier.Username
            })
            .ToList();

            return this.View(viewModel);
        }

        public ActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}
