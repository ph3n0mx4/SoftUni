using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public class Soup : Food
    {
        public Soup(string name, decimal price) 
            : base(name, 245, price)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
