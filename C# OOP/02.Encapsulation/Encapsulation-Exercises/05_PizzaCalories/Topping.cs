namespace _05_PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Topping
    {
        private double weight;
        private string type;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public double Weight
        {
            get => this.weight;
            set
            {
                if(value<1 || value >50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        public string Type
        {
            get => this.type;
            set
            {
                if(value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        public double Calories()
        {
            double topping = 0;

            switch (this.Type.ToLower())
            {
                case "meat":
                    topping = 1.2;
                    break;
                case "veggies":
                    topping = 0.8;
                    break;
                case "cheese":
                    topping = 1.1;
                    break;
                case "sauce":
                    topping = 0.9;
                    break;
            }

            return 2 * this.Weight * topping;
        }
    }
}
