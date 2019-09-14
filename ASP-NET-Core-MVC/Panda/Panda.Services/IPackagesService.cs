namespace Panda.Services
{
    using Panda.Domain;
    using System.Linq;

    public interface IPackagesService
    {
        IQueryable<Package> GetUserPackagesByUserName(string name);
    }
}
