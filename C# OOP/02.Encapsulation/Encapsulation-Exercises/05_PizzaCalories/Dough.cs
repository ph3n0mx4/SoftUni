namespace _05_PizzaCalories
{
    using System;

    public class Dough
    {
        private double weight;
        private string flour;
        private string technique;

        public Dough(double weight, string flour, string technique)
        {
            this.Weight = weight;
            this.Flour = flour;
            this.Technique = technique;
        }

        public double Weight
        {
            get => this.weight;
            set
            {
                if(value <1 || value>200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public string Flour
        {
            get => this.flour;
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flour = value;
            }
        }

        public string Technique
        {
            get => this.technique;
            set
            {
                if(value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.technique = value;
            }
        }

        public double Calories()
        {
            double type=0;

            switch (this.Flour.ToLower())
            {
                case "white":
                    type=1.5;
                    break;
                case "wholegrain":
                    type = 1;
                    break;
            }

            double baking=0;

            switch (this.Technique.ToLower())
            {
                case "crispy":
                    baking = 0.9;
                    break;
                case "chewy":
                    baking = 1.1;
                    break;
                case "homemade":
                    baking = 1.0;
                    break;
            }
            return 2 * this.Weight * baking * type;
        }
    }
}
