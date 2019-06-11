namespace Panda.Services
{
    using Panda.Data;
    using Panda.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class PackageService : IPackageService
    {
        private readonly PandaDbContext context;
        private readonly IUserService userService;
        private readonly IReceiptService receiptService;
        public PackageService(PandaDbContext context, IUserService userService, IReceiptService receiptService)
        {
            this.context = context;
            this.userService = userService;
            this.receiptService = receiptService;
        }
        public void AddPackageToDb(string description, string shippingAddress, decimal weight, string recipientName)
        {
            var recipientId = this.userService.GetUserIdByUsername(recipientName);

            var package = new Package
            {
                Description = description,
                ShippingAddress = shippingAddress,
                Weight = weight,
                RecipientId = recipientId,
                Status = PackageStatus.Pending
            };

            this.context.Packages.Add(package);
            this.context.SaveChanges();
        }

        public void DeliverPackageById(string id)
        {
            this.context.Packages.FirstOrDefault(p => p.Id == id).Status = PackageStatus.Delivered;
            this.receiptService.GenerateReceiptForPackageId(id);
            this.context.SaveChanges();
        }

        public IList<Package> GetPackagesByStatusAndUserId(PackageStatus status, string userId)
        {
            return this.context.Packages
                .Where(p => p.RecipientId == userId && p.Status == status)
                .ToList();
        }
    }
}
