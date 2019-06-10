namespace Panda.App.ViewModels.InputModels
{
    using SIS.MvcFramework.Attributes.Validation;

    public class UserLoginInputModel
    {
        private const string ErrorMessage = "Both username and password are required!";

        [RequiredSis(ErrorMessage)]
        public string Username { get; set; }

        [RequiredSis(ErrorMessage)]
        public string Password { get; set; }
    }
}
