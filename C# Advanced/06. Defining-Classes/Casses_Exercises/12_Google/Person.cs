namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        public string Name  {get; set;}

        public Company Company{ get; set; }

        public Car Car { get; set; }

        public List<Parent> Parent { get; set; }

        public List<Child> Child { get; set; }

        public List<Pokemon> Pokemon { get; set; }

        public Person(string name)
        {
            Name = name;
            Parent = new List<Parent>();
            Child = new List<Child>();
            Pokemon = new List<Pokemon>();

        }

        public override string ToString()
        {
            //stava i sys stringBuilder
            string output = $"{Name}";
            output = string.Concat(output, Environment.NewLine);

            if(Company==null)
            {
                output = string.Concat(output, "Company:");
            }

            else
            {
                output = string.Concat(output, "Company:");
                output = string.Concat(output, Environment.NewLine);
                output = string.Concat(output, $"{Company.CompanyName} {Company.Department} {Company.Salary:f2}");
            }
            output = string.Concat(output, Environment.NewLine);

            if (Car == null)
            {
                output = string.Concat(output, "Car:");
            }

            else
            {
                output = string.Concat(output, "Car:");
                output = string.Concat(output, Environment.NewLine);
                output = string.Concat(output, $"{Car.Model} {Car.Speed}");
            }

            output = string.Concat(output, Environment.NewLine);

            if (Pokemon==null)
            {
                output = string.Concat(output, "Pokemon:");
            }

            else
            {
                output = string.Concat(output, "Pokemon:");
                output = string.Concat(output, Environment.NewLine);
                foreach (var item in Pokemon)
                {
                    output = string.Concat(output, $"{item.PokemonName} {item.Type}");
                    output = string.Concat(output, Environment.NewLine);
                }
            }

            if (Parent == null)
            {
                output = string.Concat(output, "Parents:");
            }

            else
            {
                output = string.Concat(output, "Parents:");
                output = string.Concat(output, Environment.NewLine);
                foreach (var item in Parent)
                {
                    output = string.Concat(output, $"{item.ParentName} {item.ParentBirthday}");
                    output = string.Concat(output, Environment.NewLine);
                }
            }

            if (Child == null)
            {
                output = string.Concat(output, "Children:");
            }

            else
            {
                output = string.Concat(output, "Children:");
                output = string.Concat(output, Environment.NewLine);
                foreach (var item in Child)
                {
                    output = string.Concat(output, $"{item.ChildName} {item.Birthday}");
                    output = string.Concat(output, Environment.NewLine);
                }
            }
            return output;
        }
    }
}
