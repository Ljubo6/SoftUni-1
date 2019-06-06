namespace Musaca.Services
{
    using Musaca.Models;
    using System.Collections.Generic;

    public interface IProductService
    {
        Product AddProduct(Product product);

        IEnumerable<Product> GetAllProducts();
    }
}
