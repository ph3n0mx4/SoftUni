using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Dtos.Export;
using ProductShop.Models;

using AutoMapper;
using AutoMapper.QueryableExtensions;


namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<ProductShopProfile>());

            using (var db = new ProductShopContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //var inputXml = File.ReadAllText("./../../../Datasets/users.xml");
                //var inputXml = File.ReadAllText("./../../../Datasets/products.xml");
                //var inputXml = File.ReadAllText("./../../../Datasets/categories.xml");
                //var inputXml = File.ReadAllText("./../../../Datasets/categories-products.xml");

                //var result = ImportUsers(db, inputXml);
                //var result = ImportProducts(db, inputXml);
                //var result = ImportCategories(db, inputXml);
                //var result = ImportCategoryProducts(db, inputXml);
                //var result = GetProductsInRange(db);
                //var result = GetSoldProducts(db);
                //var result = GetCategoriesByProductsCount(db);
                var result = GetUsersWithProducts(db);

                Console.WriteLine(result);
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]),
                new XmlRootAttribute("Users"));

            ImportUserDto[] userDtos;

            using (var reader = new StringReader(inputXml))
            {
                userDtos = (ImportUserDto[])xmlSerializer.Deserialize(reader);
            }
            var users = Mapper.Map<User[]>(userDtos);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ImportProductDto>),
                new XmlRootAttribute("Products"));

            int result;

            using (var reader = new StringReader(inputXml))
            {
                var productDtos = (List<ImportProductDto>)xmlSerializer.Deserialize(reader);

                var products = Mapper.Map<List<Product>>(productDtos);


                context.Products.AddRange(products);
                result = context.SaveChanges();
            }

            return $"Successfully imported {result}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ImportCategoryDto>),
                new XmlRootAttribute("Categories"));

            int result;

            using (var reader = new StringReader(inputXml))
            {
                var categoryDtos = ((List<ImportCategoryDto>)xmlSerializer.Deserialize(reader))
                    .Where(p => p.Name != null)
                    .ToList();

                var categories = Mapper.Map<List<Category>>(categoryDtos);
                result = categories.Count();

                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            return $"Successfully imported {result}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ImportCategoryProductDto>),
                new XmlRootAttribute("CategoryProducts"));

            int result;

            using (var reader = new StringReader(inputXml))
            {
                var productIds = context
                    .Products
                    .Select(p => p.Id)
                    .ToList();

                var categoryIds = context
                    .Categories
                    .Select(c => c.Id)
                    .ToList();

                var categoryProductDtos = ((List<ImportCategoryProductDto>)xmlSerializer.Deserialize(reader))
                    .Where(cp => productIds.Contains(cp.ProductId)
                    && categoryIds.Contains(cp.CategoryId))
                    .ToList();

                var categoriesProducts = Mapper.Map<List<CategoryProduct>>(categoryProductDtos);

                result = categoriesProducts.Count();

                context.CategoryProducts.AddRange(categoriesProducts);
                context.SaveChanges();
            }
            return $"Successfully imported {result}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ExportProductInRangeDto>()
                .ToArray();


            var xmlSerializer = new XmlSerializer(typeof(ExportProductInRangeDto[]),
                new XmlRootAttribute("Products"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, products, namespaces);
            }
            
            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new GetSoldProductDto
                {
                    FirstName = u.FirstName,
                    LastName= u.LastName,
                    SoldProducts = u.ProductsSold.Select(ps => new ExportProductInRangeDto
                    {
                        Name = ps.Name,
                        Price = ps.Price
                    }).ToArray()
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(GetSoldProductDto[]),
                new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, users, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new GetCategoriesByProductsCountDto
                {
                    Name = c.Name,
                    ProductsCount= c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(p=>p.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p=>p.Product.Price)
                })
                .OrderByDescending(c=>c.ProductsCount)
                .ThenBy(c=>c.TotalRevenue)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(GetCategoriesByProductsCountDto[]),
                new XmlRootAttribute("Categories"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, categories, namespaces);
            }
                
            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u=>u.ProductsSold.Count())
                .Select(u => new GetUsersWithProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsCountDto
                    {
                        Count = u.ProductsSold.Count(),
                        Products = u.ProductsSold
                            .Select(ps => new ExportProductInRangeDto
                            {
                                Name = ps.Name,
                                Price = ps.Price
                            })
                            .OrderByDescending(ps=>ps.Price)
                            .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            var resultUsers = new UserAndProductDto
            {
                Count = context.Users.Where(u => u.ProductsSold.Any()).Count(),
                Users = users
            };

            var xmlSerializer = new XmlSerializer(typeof(UserAndProductDto),
                new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, resultUsers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}