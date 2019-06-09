namespace Panda.Services
{
    using Panda.Models;
    using System.Collections.Generic;

    public interface IReceiptService
    {
        Receipt GenerateReceiptForPackageId(string id);
        IList<Receipt> GetAllReceiptByUserId(string userId);
    }
}
