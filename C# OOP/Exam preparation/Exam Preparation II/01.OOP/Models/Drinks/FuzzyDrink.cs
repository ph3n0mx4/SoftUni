using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public class FuzzyDrink : Drink
    {
        public FuzzyDrink(string name, int servingSize, string brand) 
            : base(name, servingSize, 2.50m, brand)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
