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
        public Product AddNewProductToDb(string name, decimal price)
        {
            var product = new Product
            {
                Name = name,
                Price = price
            };

            product = this.musacaContext.Products.Add(product).Entity;
            this.musacaContext.SaveChanges();
            return product;
        }

        public IQueryable<Product> GetAllProducts()
        {
            return this.musacaContext.Products;
        }

        public Product GetProductByName(string name)
        {
            return this.GetAllProducts().FirstOrDefault(p => p.Name == name);
        }
    }
}
