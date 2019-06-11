namespace Panda.App.Controllers
{
    using Panda.App.ViewModels.InputModels;
    using Panda.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;

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
        public IActionResult Register(RegisterInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if(inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            this.userService.AddUser(inputModel.Username, inputModel.Email, inputModel.Password);
            return this.Redirect("/Users/Login");
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginInputModel inputModel)
        {
            var userFromDb = this.userService
                .GetUserByUsernameAndPassword(inputModel.Username, inputModel.Password);

            if (userFromDb == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userFromDb.Id, userFromDb.Username, userFromDb.Email);
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
