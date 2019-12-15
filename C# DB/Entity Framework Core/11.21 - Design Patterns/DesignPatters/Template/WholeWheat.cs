﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Template
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {

            Console.WriteLine("Baking the WholeWheat Bread. (15 minutes)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for WholeWheat Bread");
        }
    }
}
