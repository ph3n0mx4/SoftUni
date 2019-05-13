using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public class Dessert : Food
    {
        public Dessert(string name, decimal price) 
            : base(name, 200, price)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
