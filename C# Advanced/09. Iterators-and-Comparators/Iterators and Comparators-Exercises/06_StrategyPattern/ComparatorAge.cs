namespace _06_StrategyPattern
{
    using System;

    public class ComparatorAge : Person, IComparable<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            return this.Age - other.Age;
        }
    }
}
