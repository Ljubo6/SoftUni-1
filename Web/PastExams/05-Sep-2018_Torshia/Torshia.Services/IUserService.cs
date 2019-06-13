namespace Torshia.Services
{
    using Torshia.Models;

    public interface IUserService
    {
        User AddNewUserToDb(string username, string password, string email);
        User GetUserByUsernameAndPassword(string username, string password);
        User GetUserByUsername(string username);
    }
}
