namespace Musaca.Services
{
    using Musaca.Models;
    using System.Linq;

    public interface IProductService
    {
        Product AddNewProductToDb(string name, decimal price);
        Product GetProductByName(string name);
        IQueryable<Product> GetAllProducts();
    }
}
