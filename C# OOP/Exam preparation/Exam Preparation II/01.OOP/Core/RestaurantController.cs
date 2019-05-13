namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Models.Drinks;
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RestaurantController
    {
        private List<IFood> menu;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal income;

        public RestaurantController()
        {
            menu = new List<IFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
            income = 0;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IFood food;
            
            if(type=="Dessert")
            {
                food = new Dessert(name,price);
                this.menu.Add(food);
            }

            else if (type == "MainCourse")
            {
                food = new MainCourse(name, price);
                this.menu.Add(food);
            }

            else if (type == "Soup")
            {
                food = new Soup(name, price);
                this.menu.Add(food);
            }

            else if (type == "Salad")
            {
                food = new Salad(name, price);
                this.menu.Add(food);
            }

            else
            {
                food = null;
            }
            return $"Added {name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink; 
            if(type=="Alcohol")
            {
                drink = new Alcohol(name, servingSize, brand);
                drinks.Add(drink);
            }

            else if (type== "FuzzyDrink")
            {
                drink = new FuzzyDrink(name, servingSize, brand);
                drinks.Add(drink);
            }

            else if (type == "Juice")
            {
                drink = new Juice(name, servingSize, brand);
                drinks.Add(drink);
            }

            else if (type == "Water")
            {
                drink = new Water(name, servingSize, brand);
                drinks.Add(drink);
            }

            else
            {
                drink = null;
            }
            return $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table;
            if(type== "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
                tables.Add(table);
            }

            else if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
                tables.Add(table);
            }

            else
            {
                table = null;
            }
            return $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable a = tables.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);

            if(a==null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            tables.First(p => p.TableNumber == a.TableNumber).Reserve(numberOfPeople);
            return $"Table {a.TableNumber} has been reserved for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if(table==null)
            {
                return $"Could not find table with {tableNumber}";
            }

            var food = menu.FirstOrDefault(f => f.Name == foodName);

            if(food==null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            if (!tables.Any(t => t.TableNumber == tableNumber))
            {
                return $"Could not find table with {tableNumber}";
            }

            if(!drinks.Any(d=>d.Name==drinkName && d.Brand==drinkBrand))
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            tables.First(p => p.TableNumber == tableNumber)
                .OrderDrink(drinks.First(d => d.Name == drinkName && d.Brand == drinkBrand));
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            var a = tables.First(p => p.TableNumber == tableNumber);
            tables.First(p => p.TableNumber == tableNumber).Clear();
            this.income += a.GetBill();
            var sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {a.GetBill():f2}");
            return sb.ToString().TrimEnd();
        }

        public string GetFreeTablesInfo()
        {
            var sb = new StringBuilder();

            foreach (var table in this.tables.Where(t => t.IsReserved==false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            var sb = new StringBuilder();

            foreach (var table in this.tables.Where(t => t.IsReserved == true))
            {
                sb.AppendLine(table.GetOccupiedTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {this.income:f2}lv";
        }
    }
}
