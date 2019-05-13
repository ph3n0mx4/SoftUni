namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RandomList:List<string>
    {
        private Random rnd;

        public RandomList()
        {
            rnd = new Random();
        }

        public string RandomString()
        {
            int rndIndex = this.rnd.Next(0, this.Count);
            this.RemoveAt(rndIndex);
            return this[rndIndex];
        }

    }
}
