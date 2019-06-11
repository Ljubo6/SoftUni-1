namespace Panda.Services
{
    using Panda.Models;
    using System.Collections.Generic;

    public interface IPackageService
    {
        void AddPackageToDb(string description, string shippingAddress, decimal weight, string recipientName);
        IList<Package> GetPackagesByStatusAndUserId(PackageStatus status, string userId);
        void DeliverPackageById(string id);
    }
}
