namespace CarDealer
{
    using AutoMapper;
    using Data;
    using Dtos.Import;
    using Dtos.Export;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.Text;
    using System.Xml;

    public class StartUp
    {
        private static readonly XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
        {
            new XmlQualifiedName("","")
        });

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

            var output = GetSalesWithAppliedDiscount(context);
            Console.WriteLine(output);
        }

        //P11. Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var exportSaleSDtos = context.Sales
                .Select(s => new ExportSaleDTO
                {
                    Car = new ExportSaleCarDTO
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount,
                    Price = s.Car.PartCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(p => p.Part.Price) * (1m - s.Discount/100m)
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportSaleDTO[]), new XmlRootAttribute("sales"));
            var result = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(result), exportSaleSDtos, namespaces);

            return result.ToString().TrimEnd();
        }

        //P10. Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var exportCustomersCarsDto = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new ExportCustomerCarsDTO
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(cp => cp.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCustomerCarsDTO[]), new XmlRootAttribute("customers"));
            var result = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(result), exportCustomersCarsDto, namespaces);

            return result.ToString().TrimEnd();
        }

        //P09. Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var exportCarPartsDtos = context.Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new ExportCarPartsDTO
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                    .OrderByDescending(p => p.Part.Price)
                    .Select(p => new ExportPartDTO
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .ToArray()
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCarPartsDTO[]), new XmlRootAttribute("cars"));
            var result = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(result), exportCarPartsDtos, namespaces);

            return result.ToString().TrimEnd();
        }

        //P08. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var exportLocalSupplierDtos = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSuppliersDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportLocalSuppliersDTO[]), new XmlRootAttribute("suppliers"));
            var result = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(result), exportLocalSupplierDtos, namespaces);

            return result.ToString().TrimEnd();
        }

        //P07. Cars from make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var exportBmwDtos = context.Cars
                                .Where(c => c.Make.ToLower() == "bmw")
                                .OrderBy(c => c.Model)
                                .ThenByDescending(c => c.TravelledDistance)
                                .Select(c => new ExportBmwDTO
                                {
                                    Id = c.Id,
                                    Model = c.Model,
                                    TravelledDistance = c.TravelledDistance
                                })
                                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportBmwDTO[]), new XmlRootAttribute("cars"));
            var result = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(result), exportBmwDtos, namespaces);

            return result.ToString().TrimEnd();
        }

        //P06.Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var exportCarDtos = context.Cars
                                .Where(c => c.TravelledDistance > 2_000_000m)
                                .OrderBy(c => c.Make)
                                .ThenBy(c => c.Model)
                                .Take(10)
                                .Select(c => new ExportCarDistanceDTO
                                {
                                    Make = c.Make,
                                    Model = c.Model,
                                    TravelledDistance = c.TravelledDistance
                                })
                                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCarDistanceDTO[]), new XmlRootAttribute("cars"));
            var result = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(result), exportCarDtos, namespaces);

            return result.ToString().TrimEnd();
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