using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new ProductShopContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //var inputJson = File.ReadAllText("./../../../Datasets/users.json");
                //var inputJson = File.ReadAllText("./../../../Datasets/products.json");
                //var inputJson = File.ReadAllText("./../../../Datasets/categories.json");
                //var inputJson = File.ReadAllText("./../../../Datasets/categories-products.json");

                //var result = ImportUsers(db, inputJson);
                //var result = ImportProducts(db, inputJson);
                //var result = ImportCategories(db, inputJson);
                //var result = ImportCategoryProducts(db, inputJson);
                //var result = GetProductsInRange(db);
                //var result = GetSoldProducts(db);
                //var result = GetCategoriesByProductsCount(db);
                var result = GetUsersWithProducts(db);

                Console.WriteLine(result);
                
            }

        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(c=>c.Name != null)
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p=>p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToList();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Count >= 1 && u.ProductsSold.Any(s => s.BuyerId != null))
                .OrderBy(u=>u.LastName)
                .ThenBy(u=>u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                    .Select(s => new
                    {
                        name = s.Name,
                        price = s.Price,
                        buyerFirstName = s.Buyer.FirstName,
                        buyerLastName = s.Buyer.LastName
                    })
                })
                .ToList();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = $"{c.CategoryProducts.Average(p => p.Product.Price):f2}",
                    totalRevenue = $"{c.CategoryProducts.Sum(p => p.Product.Price):f2}"
                })
                .ToList();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p=>p.Buyer !=null))
                //.OrderByDescending(u => u.ProductsSold.Count)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold
                                .Where(p=>p.Buyer != null)
                                .Count(),
                        products = u.ProductsSold
                                .Where(ps => ps.Buyer != null)
                                .Select(ps => new
                                {
                                    name = ps.Name,
                                    price = ps.Price
                                }).ToList()
                    }
                })
                .OrderByDescending(x=>x.soldProducts.count)
                .ToList();

            var usersOutput = new
            {
                usersCount = users.Count(),
                users = users
            };
            //var json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            var json = JsonConvert.SerializeObject(usersOutput, new JsonSerializerSettings()
            { 
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }
    }
}