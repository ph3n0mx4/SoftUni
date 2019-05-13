using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            var inputPeople = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var inputProducts = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var listProducts = new List<Product>();
            var listPeople = new List<Person>();

            try
            {
                for (int i = 0; i < inputProducts.Length; i++)
                {
                    var currentProduct = inputProducts[i].Split("=").ToArray();
                    string name = currentProduct[0];
                    double cost = double.Parse(currentProduct[1]);

                    var product = new Product(name, cost);
                    listProducts.Add(product);
                }
                
                for (int i = 0; i < inputPeople.Length; i++)
                {
                    var currentPerson = inputPeople[i].Split("=").ToArray();
                    string name = currentPerson[0];

                    if(string.IsNullOrEmpty(name))
                    {
                        break;
                    }

                    double money = double.Parse(currentPerson[1]);

                    var person = new Person(name, money);
                    listPeople.Add(person);
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            var cmd = Console.ReadLine().Split().ToArray();
            while (cmd[0] != "END")
            {
                string personName = cmd[0];
                string productName = cmd[1];

                listPeople.FirstOrDefault(x => x.Name == personName)
                    .AddProduct(listProducts.FirstOrDefault(p => p.Name == productName));

                cmd = Console.ReadLine().Split().ToArray();
            }

            listPeople.ForEach(p => p.Print());
        }
    }
}
