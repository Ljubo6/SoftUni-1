namespace Musaca.Services
{
    using Musaca.Models;

    public interface IUserService
    {
        User AddUser(User user);
        User GetUserByUsernameAndPassword(string username, string password);
    }
}
