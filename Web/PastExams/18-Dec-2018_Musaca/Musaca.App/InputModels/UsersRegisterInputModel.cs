namespace Musaca.App.InputModels
{
    using SIS.MvcFramework.Attributes.Validation;

    public class UsersRegisterInputModel
    {
        private const int minLength = 5;
        private const int maxLength = 20;
        private const string usernameLengthErrorMessage = "Username must be between 5 and 20 characters";
        private const string emailLengthErrorMessage = "Username must be between 5 and 20 characters";


        [RequiredSis]
        [StringLengthSis(minLength, maxLength, usernameLengthErrorMessage)]
        public string Username { get; set; }

        [RequiredSis]
        public string Password { get; set; }

        [RequiredSis]
        public string ConfirmPassword { get; set; }

        [RequiredSis]
        [StringLengthSis(minLength, maxLength, emailLengthErrorMessage)]
        public string Email { get; set; }
    }
}
