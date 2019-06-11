namespace Panda.Services
{
    using Panda.Data;
    using Panda.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReceiptService : IReceiptService
    {
        private readonly PandaDbContext context;
        public ReceiptService(PandaDbContext context)
        {
            this.context = context;
        }
        public Receipt GenerateReceiptForPackageId(string id)
        {
            var package = this.context.Packages.FirstOrDefault(p => p.Id == id);

            var newReceipt = new Receipt
            {
                Fee = package.Weight * 2.67m,
                IssuedOn = DateTime.UtcNow,
                Package = package,
                PackageId = id,
                RecipientId = package.RecipientId,
                Recipient = this.context.Users.FirstOrDefault(u => u.Id == package.RecipientId)
            };

            newReceipt = this.context.Receipts.Add(newReceipt).Entity;
            this.context.SaveChanges();
            return newReceipt;
        }

        public IList<Receipt> GetAllReceiptByUserId(string userId)
        {
            return this.context.Receipts.Where(r => r.RecipientId == userId).ToList();
        }
    }
}
