using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new CarDealerContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //var inputJson = File.ReadAllText("./../../../Datasets/suppliers.json");
                //var inputJson = File.ReadAllText("./../../../Datasets/parts.json");
                //var inputJson = File.ReadAllText("./../../../Datasets/cars.json");
                //var inputJson = File.ReadAllText("./../../../Datasets/customers.json");
                //var inputJson = File.ReadAllText("./../../../Datasets/sales.json");

                //var result = ImportSuppliers(db, inputJson);
                //var result = ImportParts(db, inputJson);
                //var result = ImportCars(db, inputJson);
                //var result = ImportCustomers(db, inputJson);
                //var result = ImportSales(db, inputJson);
                //var result = GetOrderedCustomers(db);
                //var result = GetCarsFromMakeToyota(db);
                //var result = GetLocalSuppliers(db);
                //var result = GetCarsWithTheirListOfParts(db);
                //var result = GetTotalSalesByCustomer(db);
                var result = GetSalesWithAppliedDiscount(db);

                Console.WriteLine(result);
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<List<ImportCarDto>>(inputJson);

            var cars = new List<Car>();

            var carParts = new List<PartCar>();

            foreach (var carDto in carsDto)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model =carDto.Model,
                    TravelledDistance=carDto.TravelledDistance
                };

                foreach (var part in carDto.PartsId.Distinct())
                {
                    var carPart = new PartCar()
                    {
                        PartId = part,
                        Car=car
                    };

                    carParts.Add(carPart);
                }

                cars.Add(car);
            }
            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c=>c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate=c.BirthDate.ToString(@"dd\/MM\/yyyy"),
                    c.IsYoungDriver
                })
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make.ToLower() == "toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars.Select(pc => new
                    {
                        Name = pc.Part.Name,
                        Price = $"{pc.Part.Price:f2}"
                    })

                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    fullName = $"{c.Name}",
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(x => x.Car.PartCars.Sum(y => y.Part.Price))
                })
                .OrderByDescending(c=>c.spentMoney)
                .ThenByDescending(c=>c.boughtCars)
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return json;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            //var sales = context.Sales
            //    .Select(s => new
            //    {
            //        car = new 
            //        {
            //            Make = s.Car.Make,
            //            Model = s.Car.Model,
            //            TravelledDistance = s.Car.TravelledDistance
            //        },
            //        customerName = s.Customer.Name,
            //        Discount = $"{s.Discount:F2}",
            //        price = $"{s.Car.PartCars.Sum(p => p.Part.Price):F2}",
            //        priceWithDiscount = $@"{(s.Car.PartCars.Sum(p => p.Part.Price) -
            //            s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100):F2}"
            //    })
            //    .Take(10)
            //    .ToList();

            //var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            //return json;

            var sales = context
                .Sales

                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount,
                    price = s.Car.PartCars.Sum(y => y.Part.Price),
                    priceWithDiscount = $@"{(s.Car.PartCars.Sum(y => y.Part.Price) * (1 - s.Discount / 100)):f2}"
                })
                .Take(10)
                .ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);
            return json;
        }
    }
}