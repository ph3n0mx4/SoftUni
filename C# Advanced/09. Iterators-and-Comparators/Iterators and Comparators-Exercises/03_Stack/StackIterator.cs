using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_Stack
{
    public class StackIterator<T> : IEnumerable<T>
    {
        //public Stack<T> Stack { get; set; }
        private List<T> data = new List<T>();

        public void Pop()
        {
            if(this.data.Count==0)
            {
                throw new ArgumentException("No elements");
            }
            data.RemoveAt(data.Count - 1);
        }

        public void Push(params T[] data)
        {
            this.data.AddRange(data);
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = data.Count - 1; i >=0; i--)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
    }
}
