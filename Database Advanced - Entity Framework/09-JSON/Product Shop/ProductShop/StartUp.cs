using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //string inputJson = File.ReadAllText(@"..\..\..\Datasets\categories-products.json");

            using (var context = new ProductShopContext())
            {
                context.Database.EnsureCreated();
                var output = GetCategoriesByProductsCount(context);
                Console.WriteLine(output);
            }
        }

        //P08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            return string.Empty;
        }


        //P07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductsCount = context.CategoryProducts
                .GroupBy(cp => cp.Category)
                .Select(g => new CategoryDTO
                {
                    Name = g.Key.Name,
                    ProductsCount = g.Select(p => p.Product).Count(),
                    AveragePrice = Math.Round(g.Select(p => p.Product.Price).Average(), 2),
                    TotalRevenue = Math.Round(g.Select(p => p.Product.Price).Sum(), 2)
                })
                .OrderByDescending(c => c.ProductsCount)
                .ToArray();

            var jsonString = JsonConvert.SerializeObject(categoriesByProductsCount, Formatting.Indented);
            return jsonString;
        }

        //P06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .Select(u => new UserWithSoldItemsDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                                    .Where(ps => ps.Buyer != null)
                                    .Select(ps => new SoldItemDTO
                                    {
                                        Name = ps.Name,
                                        BuyerFirstName = ps.Buyer.FirstName,
                                        BuyerLastName = ps.Buyer.LastName,
                                        Price = ps.Price
                                    })
                                    .ToList()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();

            var jsonString = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);
            return jsonString;
        }

        //P05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .OrderBy(p => p.Price)
                .ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonString = JsonConvert.SerializeObject(productsInRange, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            return jsonString;
        }

        //P04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoriesProducts);
            var categoriesProductsEntered = context.SaveChanges();
            return $"Successfully imported {categoriesProductsEntered}";
        }

        //P03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null && c.Name.Length >= 3 && c.Name.Length <= 15)
                .ToArray();

            context.Categories.AddRange(categories);
            var categoriesEntered = context.SaveChanges();
            return $"Successfully imported {categoriesEntered}";
        }

        //P02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson)
                .Where(p => p.Name != null && p.Name.Length > 2)
                .ToArray();

            context.Products.AddRange(products);
            var productsEntered = context.SaveChanges();
            return $"Successfully imported {productsEntered}";
        }

        //P01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson)
                .Where(u => u.LastName != null && u.LastName.Length > 2)
                .ToArray();

            context.Users.AddRange(users);
            var usersEntered = context.SaveChanges();

            return $"Successfully imported {usersEntered}";
        }
    }
}