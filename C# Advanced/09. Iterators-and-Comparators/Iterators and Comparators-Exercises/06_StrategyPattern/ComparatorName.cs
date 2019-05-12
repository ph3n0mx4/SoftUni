namespace _06_StrategyPattern
{ 
    using System;

    public class ComparatorName : Person, IComparable<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            if(this.Name.Length==other.Name.Length)
            {
                if(this.Name[0]==other.Name[0])
                {
                    return 0;
                }

                else if(this.Name[0] >= other.Name[0] && this.Name[0]>=97 && this.Name[0]<=122)
                {
                    return -1;
                }

                else if (this.Name[0] >= other.Name[0] && this.Name[0] >= 65 && this.Name[0] <= 90)
                {
                    return 1;
                }

                return -1;
                
            }

            return this.Name.Length - other.Name.Length;
        }
    }
}
