using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public class Juice : Drink
    {
        public Juice(string name, int servingSize, string brand) 
            : base(name, servingSize, 1.80m, brand)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
