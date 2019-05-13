namespace SoftUniRestaurant.Models.Tables
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Table : ITable
    {
        private List<IFood> foods;
        private List<IDrink> drinks;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foods = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.IsReserved = false;
        }

        public int TableNumber { get;  private set; }
        
        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if(value<=0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get =>this.numberOfPeople;
            private set
            {
                if(value<=0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price { get => this.PricePerPerson*this.NumberOfPeople; }

        public void Clear()
        {
            foods.Clear();
            drinks.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return foods.Select(p => p.Price).Sum() + drinks.Select(p => p.Price).Sum()+ this.Price;
            //foods.Sum(p => p.Price)
        }

        public string GetFreeTableInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");
            string food = foods.Any() ? $"Food orders: {this.foods.Count}" : "Food orders: None";
            sb.AppendLine(food);
            foods.ForEach(x => sb.AppendLine(x.ToString()));
            string drink = drinks.Any() ? $"Food orders: {this.foods.Count}" : "Food orders: None";
            sb.AppendLine(drink);
            drinks.ForEach(x => sb.AppendLine(x.ToString()));

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinks.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            this.foods.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}
