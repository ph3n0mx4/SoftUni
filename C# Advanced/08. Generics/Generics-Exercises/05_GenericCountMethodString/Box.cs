using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

namespace _05_GenericCountMethodString
{
    public class Box<T>
    {
        public List<T> values { get; set; }

        public Box()
        {
            this.values = new List<T>();
        }

        public void Add(T value)
        {
            values.Add(value);
        }
    }
}
