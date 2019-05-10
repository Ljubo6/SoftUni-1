using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //var inputXml = File.ReadAllText(@"..\..\..\Datasets\categories-products.xml");

            Mapper.Initialize(cfg => cfg.AddProfile(new ProductShopProfile()));

            var context = new ProductShopContext();
            context.Database.EnsureCreated();

            var output = GetUsersWithProducts(context);
            Console.WriteLine(output);
        }

        //P08. Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProductsDto = new ExportUsersCollectionDTO
            {
                Count = context.Users.Where(u => u.ProductsSold.Count > 0).Count(),
                Users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .Select(u => new ExportUserAgeSoldProductDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductsCollectionDTO
                    {
                        Count = u.ProductsSold.Count,
                        SoldProductsArray = u.ProductsSold.Select(p => new ExportSoldProductDTO
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray(),
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .Take(10)
                .ToArray()
            };

            var xmlSerializer = new XmlSerializer(typeof(ExportUsersCollectionDTO), new XmlRootAttribute("Users"));

            var result = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(result), usersWithProductsDto, namespaces);

            return result.ToString().TrimEnd();
        }

        //P07. Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesDto = context.Categories
                .Include(cp => cp.CategoryProducts)
                .Select(c => new ExportCategoryDTO
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Select(p => p.Product.Price).Average(),
                    TotalRevenue = c.CategoryProducts.Select(p => p.Product.Price).Sum()
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCategoryDTO[]), new XmlRootAttribute("Categories"));

            var result = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(result), categoriesDto, namespaces);

            return result.ToString().TrimEnd();
        }

        //P06. Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersSoldProductsDto = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .Select(u => new ExportUsersSoldProductDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new ExportSoldProductDTO
                    {
                        Name = p.Name,
                        Price = p.Price
                    }).ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportUsersSoldProductDTO[]), new XmlRootAttribute("Users"));

            var result = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(result), usersSoldProductsDto, namespaces);

            return result.ToString().TrimEnd();
        }

        //P05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRangeDto = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ExportProductInRangeDTO
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportProductInRangeDTO[]), new XmlRootAttribute("Products"));

            var result = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(result), productsInRangeDto, namespaces);

            return result.ToString().TrimEnd();
        }

        //P04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDTO[]), new XmlRootAttribute("CategoryProducts"));
            var importedCategoryProductsDto = (ImportCategoryProductDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var importedCategoryProducts = new List<CategoryProduct>();

            foreach (var importedCPdto in importedCategoryProductsDto)
            {
                var product = context.Products.Find(importedCPdto.ProductId);
                var category = context.Categories.Find(importedCPdto.CategoryId);

                if(product != null && category != null)
                {
                    var categoryProduct = Mapper.Map<CategoryProduct>(importedCPdto);
                    importedCategoryProducts.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(importedCategoryProducts);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        //P03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryDTO[]), new XmlRootAttribute("Categories"));
            var importedCategoriesDto = (ImportCategoryDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var importedCategories = new List<Category>();

            foreach (var categoryDto in importedCategoriesDto)
            {
                var category = Mapper.Map<Category>(categoryDto);
                importedCategories.Add(category);
            }

            context.Categories.AddRange(importedCategories);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        //P02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProductDTO[]), new XmlRootAttribute("Products"));
            var importedProductsDto = (ImportProductDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var importedProducts = new List<Product>();

            foreach (var productDto in importedProductsDto)
            {
                var product = Mapper.Map<Product>(productDto);
                importedProducts.Add(product);
            }

            context.Products.AddRange(importedProducts);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        //P01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportUserDTO[]), new XmlRootAttribute("Users"));
            var importedUsersDto = (ImportUserDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var importedUsers = new List<User>();

            foreach (var userDto in importedUsersDto)
            {
                var user = Mapper.Map<User>(userDto);
                importedUsers.Add(user);
            }

            context.Users.AddRange(importedUsers);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }
    }
}