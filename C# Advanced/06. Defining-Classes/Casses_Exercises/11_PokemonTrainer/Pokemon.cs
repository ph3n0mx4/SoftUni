namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Pokemon
    {
        //Pokemon have a name, an element and health
        public string Name { get; set; }

        public string Element { get; set; }

        public int Healt { get; set; }

        public Pokemon(string name, string element, int healt)
        {
            Name = name;
            Element = element;
            Healt = healt;
        }
    }
}
