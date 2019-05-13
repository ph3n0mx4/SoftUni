using System;
using System.Collections.Generic;
using System.Text;

namespace _07_FoodShortage
{
    public interface IBuyer
    {
        int Food { get; }

        void BuyFood();
    }
}
