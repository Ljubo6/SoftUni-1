namespace CarDealer
{
    using AutoMapper;
    using Data;
    using Dtos.Import;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            Mapper.Initialize(cfg => cfg.AddProfile(new CarDealerProfile()));

            var context = new CarDealerContext();
            context.Database.EnsureCreated();

            var suppliersInputXml = File.ReadAllText(@"..\..\..\Datasets\suppliers.xml");
            var partsInputXml = File.ReadAllText(@"..\..\..\Datasets\parts.xml");
            var carsInputXml = File.ReadAllText(@"..\..\..\Datasets\cars.xml");
            var customersInputXml = File.ReadAllText(@"..\..\..\Datasets\customers.xml");
            var salesInputXml = File.ReadAllText(@"..\..\..\Datasets\sales.xml");

            var output = ImportSales(context, salesInputXml);
            Console.WriteLine(output);
        }

        //P05.Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSaleDTO[]), new XmlRootAttribute("Sales"));
            var salesDto = (ImportSaleDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var importedSales = new List<Sale>();

            foreach (var saleDto in salesDto)
            {
                if(context.Cars.Find(saleDto.CarId) != null)
                {
                    var sale = Mapper.Map<Sale>(saleDto);
                    importedSales.Add(sale);
                }
            }

            context.Sales.AddRange(importedSales);
            var count = context.SaveChanges();
            return $"Successfully imported {count}";
        }

        //P04. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerDTO[]), new XmlRootAttribute("Customers"));
            var customersDto = (ImportCustomerDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var importedCustomers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                var customer = Mapper.Map<Customer>(customerDto);
                importedCustomers.Add(customer);
            }

            context.Customers.AddRange(importedCustomers);
            var count = context.SaveChanges();
            return $"Successfully imported {count}";
        }

        //P03. ImportCars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var carsXml = XDocument.Parse(inputXml);

            var importedCars = new List<Car>();
            var count = 0;

            var partCarCollection = new List<PartCar>();

            foreach (var carXml in carsXml.Root.Elements("Car"))
            {
                var carDto = new ImportCarDTO
                {
                    Make = carXml.Element("make").Value,
                    Model = carXml.Element("model").Value,
                    TravelledDistance = long.Parse(carXml.Element("TraveledDistance").Value)
                };

                var importedCar = Mapper.Map<Car>(carDto);
                context.Cars.Add(importedCar);
                context.SaveChanges();
                count++;

                var currentCarParts = new List<int>();

                foreach (var part in carXml.Element("parts").Descendants())
                {
                    var id = int.Parse(part.Attribute("id").Value);
                    currentCarParts.Add(id);
                }

                currentCarParts = currentCarParts.Distinct().ToList();

                foreach (var id in currentCarParts)
                {
                    if (context.Parts.Find(id) != null)
                    {
                        var partCar = new PartCar
                        {
                            CarId = importedCar.Id,
                            PartId = id
                        };

                        partCarCollection.Add(partCar);
                    }
                }
            }

            context.PartCars.AddRange(partCarCollection);
            context.SaveChanges();
            return $"Successfully imported {count}";
        }

        //P02. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPartDTO[]), new XmlRootAttribute("Parts"));
            var partsDto = (ImportPartDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var importedParts = new List<Part>();

            foreach (var partDto in partsDto)
            {
                if (context.Suppliers.FirstOrDefault(s => s.Id == partDto.SupplierId) != null)
                {
                    var part = Mapper.Map<Part>(partDto);
                    importedParts.Add(part);
                }
            }

            context.Parts.AddRange(importedParts);
            var count = context.SaveChanges();
            return $"Successfully imported {count}";
        }

        //P01. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSupplierDTO[]), new XmlRootAttribute("Suppliers"));
            var suppliersDto = (ImportSupplierDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var importedSuppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = Mapper.Map<Supplier>(supplierDto);
                importedSuppliers.Add(supplier);
            }

            context.Suppliers.AddRange(importedSuppliers);
            var count = context.SaveChanges();
            return $"Successfully imported {count}";
        }
    }
}