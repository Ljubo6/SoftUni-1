namespace Torshia.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;
    using Torshia.App.InputModels;
    using Torshia.Services;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(UsersRegisterInputModel inputModel)
        {
            if (inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            this.userService.AddNewUserToDb(inputModel.Username, inputModel.Password, inputModel.Email);
            return this.Redirect("/Users/Login");
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(UsersLoginInputModel inputModel)
        {
            var userFromDb = this.userService
                .GetUserByUsernameAndPassword(inputModel.Username, inputModel.Password);

            if (userFromDb == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userFromDb.Id, userFromDb.Username, userFromDb.Email, userFromDb.Roles.ToString());
            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
