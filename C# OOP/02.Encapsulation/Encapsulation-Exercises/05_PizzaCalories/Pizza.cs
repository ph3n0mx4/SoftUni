namespace _05_PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;
        private double calories;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
            this.Calories = dough.Calories();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length>15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough
        {
            get => this.dough;
            set
            {
                this.dough = value;
            }
        }

        public double Calories { get; private set; }

        public void AddTopping(Topping topping)
        {
            if(toppings.Count>10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
            this.Calories += topping.Calories();
        }

        public double GetTotalCalories() => this.Calories;
        
    }
}
