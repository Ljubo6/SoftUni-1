using SIS.MvcFramework.Attributes.Validation;

namespace Panda.App.ViewModels.InputModels
{
    public class RegisterInputModel
    {
        private const string UsernameLengthErrorMsg = "Username should be between 5 and 20 symbols long.";
        private const string EmailLengthErrorMsg = "Email length should be between 5 and 20 symbols.";


        [RequiredSis]
        [StringLengthSis(5, 20, UsernameLengthErrorMsg)]
        public string Username { get; set; }

        [RequiredSis]
        [StringLengthSis(5, 20, EmailLengthErrorMsg)]
        [EmailSis]
        public string Email { get; set; }

        [RequiredSis]
        public string Password { get; set; }

        [RequiredSis]
        public string ConfirmPassword { get; set; }
    }
}
