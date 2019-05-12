using System;
using System.Collections.Generic;
using System.Text;

namespace _03_GenericSwapMethodString
{
    public class Box<T>
    {
        public List<T>values;

        public Box()
        {
            this.values = new List<T>();
        }

        public void Add(T value)
        {
            values.Add(value);
        }

        public void ChangeItem (int firstIndex, int secondIndex)
        {
            int x = firstIndex;
            int y = secondIndex;

            var temp = values[x];
            values[x] = values[y];
            values[y] = temp;
        }

        public override string ToString()
        {
            string output ="";

            foreach (var item in values)
            {
                output = string.Concat(output, $"{item.GetType()}: {item}");
                output = string.Concat(output, Environment.NewLine);
            }
            return output;
        }
    }
}
