using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Dtos.Export;
using CarDealer.Models;
using System.Xml;
using System.Text;
using AutoMapper.QueryableExtensions;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Mapper.Initialize(cfg => cfg.AddProfile<CarDealerProfile>());

            using (var db = new CarDealerContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //var inputXml = File.ReadAllText("./../../../Datasets/suppliers.xml");
                //var inputXml = File.ReadAllText("./../../../Datasets/parts.xml");
                //var inputXml = File.ReadAllText("./../../../Datasets/cars.xml");
                //var inputXml = File.ReadAllText("./../../../Datasets/customers.xml");
                //var inputXml = File.ReadAllText("./../../../Datasets/sales.xml");

                //var result = ImportSuppliers(db, inputXml);
                //var result = ImportParts(db, inputXml);
                //var result = ImportCars(db, inputXml);
                //var result = ImportCustomers(db, inputXml);
                //var result = ImportSales(db, inputXml);
                //var result = GetCarsWithDistance(db);
                //var result = GetCarsFromMakeBmw(db);
                //var result = GetLocalSuppliers(db);
                //var result = GetCarsWithTheirListOfParts(db);
                //var result = GetTotalSalesByCustomer(db);
                var result = GetSalesWithAppliedDiscount(db);

                Console.WriteLine(result);
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(SupplierDto[]),
                new XmlRootAttribute("Suppliers"));

            SupplierDto[] userDtos;

            using (var reader = new StringReader(inputXml))
            {
                userDtos = (SupplierDto[])xmlSerializer.Deserialize(reader);
            }
            var users = Mapper.Map<Supplier[]>(userDtos);

            context.Suppliers.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<PartDto>),
                    new XmlRootAttribute("Parts"));

            int result;

            using (var reader = new StringReader(inputXml))
            {
                var supplierIds = context
                    .Suppliers
                    .Select(s => s.Id)
                    .ToArray();

                var partDtos = ((List<PartDto>)xmlSerializer.Deserialize(reader))
                    .Where(p => supplierIds.Contains(p.SupplierId))
                    .ToList();

                var parts = Mapper.Map<List<Part>>(partDtos);
                result = parts.Count();

                context.Parts.AddRange(parts);
                context.SaveChanges();
            }

            return $"Successfully imported {result}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CarDto[]),
                new XmlRootAttribute("Cars"));

            var cars = new List<Car>();
            var partCars = new List<PartCar>();

            using (var reader = new StringReader(inputXml))
            {
                var carDtos = ((CarDto[])xmlSerializer.Deserialize(reader));

                foreach (var carDto in carDtos)
                {
                    var car = new Car
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TravelledDistance = carDto.TravelledDistance
                    };

                    var parts = carDto
                        .Parts
                        .Where(pDto => context.Parts.Any(p => pDto.Id == p.Id))
                        .Select(p => p.Id)
                        .Distinct();

                    foreach (var partId in parts)
                    {
                        var partCar = new PartCar()
                        {
                            PartId = partId,
                            Car=car
                        };

                        partCars.Add(partCar);
                    }

                    cars.Add(car);
                }
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CustomerDto[])
                , new XmlRootAttribute("Customers"));

            int result;

            using (var reader = new StringReader(inputXml))
            {
                var supplierIds = context
                    .Suppliers
                    .Select(s => s.Id)
                    .ToArray();

                var customerDtos = ((CustomerDto[])xmlSerializer.Deserialize(reader))
                    .ToArray();

                var customers = Mapper.Map<List<Customer>>(customerDtos);
                result = customers.Count();

                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            return $"Successfully imported {result}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<SaleDto>),
                    new XmlRootAttribute("Sales"));

            int result;

            using (var reader = new StringReader(inputXml))
            {
                var carIds = context
                    .Cars
                    .Select(c => c.Id)
                    .ToArray();

                var saleDtos = ((List<SaleDto>)xmlSerializer.Deserialize(reader))
                    .Where(s => carIds.Contains(s.CarId))
                    .ToList();

                var sales = Mapper.Map<List<Sale>>(saleDtos);
                result = sales.Count();

                context.Sales.AddRange(sales);
                context.SaveChanges();
            }

            return $"Successfully imported {result}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<GetCarsWithDistanceDto>()
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(GetCarsWithDistanceDto[]),
                new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, cars, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make.ToLower() == "bmw")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<GetCarsFromMakeBmwDto>()
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(GetCarsFromMakeBmwDto[]),
                new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();

            using( var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, cars, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => !s.IsImporter)
                .ProjectTo<GetLocalSuppliersDto>()
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(GetLocalSuppliersDto[]),
                new XmlRootAttribute("suppliers"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, suppliers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new GetCarsWithTheirListOfPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                        .Select(pc => new ListPartDto
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        })
                        .OrderByDescending(pc => pc.Price)
                        .ToArray()
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(GetCarsWithTheirListOfPartsDto[]),
                new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, cars, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Any())
                .Select(c => new GetTotalSalesByCustomer
                {
                    Name = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(car => car.Car.PartCars.Sum(d => d.Part.Price))
                })
                .OrderByDescending(c=>c.SpentMoney)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(GetTotalSalesByCustomer[]),
                new XmlRootAttribute("customers"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, customers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(s => new GetSalesWithAppliedDiscount
                {
                    Car = new GetCarsWithDistanceDto2
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    //Price=s.Car.PartCars.Sum(x=>x.Car.PartCars.Sum(y=>y.Part.Price)),
                    Price = s.Car.PartCars.Sum(x => x.Part.Price),
                    PriceWithDiscount = (s.Car.PartCars.Sum(p => p.Part.Price) -
                        s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100)
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(GetSalesWithAppliedDiscount[]),
                new XmlRootAttribute("sales"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, sales, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}