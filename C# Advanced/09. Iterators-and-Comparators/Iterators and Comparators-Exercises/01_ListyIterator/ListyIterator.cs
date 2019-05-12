namespace _01_ListyIterator
{
    using System.Collections.Generic;

    public class ListyIterator<T>
    {
        private List<T> data;
        private int index;
        public ListyIterator(List<T> data)
        {
            this.data = data;
            this.index = 0;
        }

        public bool Move()
        {
            if(HasNext())
            {
                this.index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return index+1 < data.Count;
        }

        public string Print()
        {
            if(data.Count==0)
            {
                return "Invalid Operation!";
            }
            return this.data[index].ToString();
        }
    }
}
