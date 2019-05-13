using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public class Salad : Food
    {
        public Salad(string name, decimal price) 
            : base(name, 300, price)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
