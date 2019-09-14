namespace Panda.Services
{
    using Microsoft.EntityFrameworkCore;
    using Panda.Data;
    using Panda.Domain;
    using System.Linq;

    public class PackagesService : IPackagesService
    {
        private readonly PandaDbContext context;

        public PackagesService(PandaDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Package> GetUserPackagesByUserName(string name)
        {
            return this.context.Packages
                    .Where(package => package.Recipient.UserName == name)
                    .Include(Package => Package.Status);
        }
    }
}
