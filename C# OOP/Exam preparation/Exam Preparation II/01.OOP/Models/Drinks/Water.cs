using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public class Water : Drink
    {
        public Water(string name, int servingSize, string brand) 
            : base(name, servingSize, 1.50m, brand)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
