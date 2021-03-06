﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Tuple
{
    public class Tuple<T, K>
    {
        public T Item1 { get; set; }

        public K Item2 { get; set; }

        public Tuple(T item1, K item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public override string ToString()
        {
            return $"{Item1} -> {Item2}";
        }
    }
}
