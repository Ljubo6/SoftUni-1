namespace Panda.Services
{
    using Panda.Models;
    using System.Collections.Generic;

    public interface IPackageService
    {
        Package AddPackageToDb(Package package);
        IList<Package> GetPendingPackagesByUserId(string userId);
        void DeliverPackageById(string id);
        IList<Package> GetDeliveredPackagesByUserId(string userId);
    }
}
