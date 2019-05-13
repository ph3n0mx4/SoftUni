namespace _04_ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Person
    {
        private string name;
        private double money;
        private List<Product> bag;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            bag = new List<Product>();
        }

        public string Name
        {
            get => this.name;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public double Money
        {
            get => this.money;

            set
            {
                if(value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public void AddProduct(Product product)
        {
            if(product.Cost>this.money)
            {
                Console.WriteLine($"{this.name} can't afford {product.Name}");
            }

            else
            {
                this.Money -= product.Cost;
                Console.WriteLine($"{this.name} bought {product.Name}");
                bag.Add(product);
                
            }
        }

        public void Print()
        {
            if (this.bag.Count == 0)
            {//Mimi – Nothing bought 
                Console.WriteLine($"{this.name} - Nothing bought");
            }

            else
            {
                Console.WriteLine($"{this.name} - {string.Join(", ", bag.Select(p=>p.Name))}");
            }
            
        }
    }
}
