namespace Panda.Services
{
    using Panda.Data;
    using Panda.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class PackageService : IPackageService
    {
        private readonly PandaDbContext context;
        public PackageService(PandaDbContext context)
        {
            this.context = context;
        }
        public Package AddPackageToDb(Package package)
        {
            package = this.context.Packages.Add(package).Entity;
            this.context.SaveChanges();
            return package;
        }

        public void DeliverPackageById(string id)
        {
            this.context.Packages.FirstOrDefault(p => p.Id == id).Status = Status.Delivered;
            this.context.SaveChanges();
        }

        public IList<Package> GetDeliveredPackagesByUserId(string userId)
        {
            return this.context.Packages
                .Where(p => p.RecipientId == userId && p.Status == Status.Delivered)
                .ToList();
        }

        public IList<Package> GetPendingPackagesByUserId(string userId)
        {
            return this.context.Packages
                .Where(p => p.RecipientId == userId && p.Status == Status.Pending)
                .ToList();
        }
    }
}
