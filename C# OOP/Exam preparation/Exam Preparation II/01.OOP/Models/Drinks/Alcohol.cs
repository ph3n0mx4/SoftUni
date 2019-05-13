using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public class Alcohol : Drink
    {
        public Alcohol(string name, int servingSize, string brand) 
            : base(name, servingSize, 3.50m, brand)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
