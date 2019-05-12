namespace BoxOfT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Box<T>
    {
        private List<T> values;

        public Box()
        {
            this.values = new List<T>();
        }
        public void Add (T value)
        {
            values.Add(value);
        }

        public T Remove ()
        {
            var remove = this.values.Last();
            this.values.RemoveAt(values.Count - 1);
            return remove;
        }

        public int Count
        {
            get
            {
                return values.Count;
            }
        }

    }
}
