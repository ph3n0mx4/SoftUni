namespace _05_ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person: IComparable<Person>
    {
        public string  Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public int CompareTo(Person other)
        {
            var name = this.Name.CompareTo(other.Name);

            var age = this.Age - other.Age;

            var town = this.Town.CompareTo(other.Town);

            if(name==0)
            {
                if(age==0)
                {
                    if(town==0)
                    {
                        return 0;
                    }

                    return town;
                }

                return age;
            }

            return name;


        }
    }
}
