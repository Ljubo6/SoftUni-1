namespace Musaca.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Musaca.Data;
    using Musaca.Models;

    public class ProductService : IProductService
    {
        private readonly MusacaDbContext musacaContext;
        public ProductService(MusacaDbContext context)
        {
            this.musacaContext = context;
        }
        public Product AddProduct(Product product)
        {
            product = this.musacaContext.Products.Add(product).Entity;
            this.musacaContext.SaveChanges();
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return this.musacaContext.Products.ToList();
        }
    }
}
