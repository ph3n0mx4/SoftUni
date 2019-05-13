namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Database
    {
        private const int defaultSize = 16;
        private int[] database;
        private int index;

        public Database(params int [] collection)
        {
            this.index = 0;
            this.database = new int[defaultSize];
            this.ValidateCollectionSize(collection);
            this.DatabaseElements = collection;
        }

        public int[] DatabaseElements
        {
            get
            {
                var nums = new List<int>();
                for (int i = 0; i < this.index; i++)
                {
                    nums.Add(database[i]);
                }
                return nums.ToArray();
            }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    this.database[this.index] = value[i];
                    this.index++;
                }
            }
        }

        public void Add(int number)
        {
            if(this.index>=16)
            {
                throw new InvalidOperationException("Database is full");
            }

            this.database[this.index] = number;
            this.index++;
        }

        public void Remove()
        {
            if(this.index==0)
            {
                throw new InvalidOperationException("Database is empty");
            }
            this.database[this.index - 1] = default(int);
            this.index--;
        }
        private void ValidateCollectionSize(int[] collection)
        {
            if (collection.Length > 16 || collection.Length < 1)
            {
                throw new InvalidOperationException("Invalid collection size");
            }
        }
    }
}
