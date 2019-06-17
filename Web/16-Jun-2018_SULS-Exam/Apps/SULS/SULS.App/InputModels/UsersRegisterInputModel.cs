namespace SULS.App.InputModels
{
    using SIS.MvcFramework.Attributes.Validation;

    public class UsersRegisterInputModel
    {
        private const int UsernameMinLength = 5;
        private const int UsernameMaxLength = 20;
        private const string UsernameErrorMsg = "Username must be between 5 and 20 characters";

        private const int PasswordMinLength = 6;
        private const int PasswordMaxLength = 20;
        private const string PassordErrorMsg = "Password must be between 5 and 20 characters";

        private const string EmailErrorMsg = "Email is invalid";


        [RequiredSis]
        [StringLengthSis(UsernameMinLength, UsernameMaxLength, UsernameErrorMsg)]
        public string Username { get; set; }

        [EmailSis(EmailErrorMsg)]
        public string Email { get; set; }

        [RequiredSis]
        [StringLengthSis(PasswordMinLength, PasswordMaxLength, PassordErrorMsg)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
