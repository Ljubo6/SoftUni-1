namespace Panda.App.Controllers
{
    using Panda.App.ViewModels.InputModels;
    using Panda.Models;
    using Panda.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Action;
    using SIS.MvcFramework.Mapping;
    using SIS.MvcFramework.Result;
    using System.Security.Cryptography;
    using System.Text;

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
                return this.Redirect("/Users/Login");
            }

            var newDbUser = new User()
            {
                Username = inputModel.Username,
                Email = inputModel.Email,
                Password = this.HashPassword(inputModel.Password)
            };

            this.userService.AddUser(newDbUser);

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
                .GetUserByUsernameAndPassword(inputModel.Username, this.HashPassword(inputModel.Password));
                
            if (userFromDb == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userFromDb.Id, userFromDb.Username, userFromDb.Email);

            return this.Redirect("/Home/Index");
        }

        public IActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }

        [NonAction]
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
