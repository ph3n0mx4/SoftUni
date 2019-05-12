namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Cargo
    {
        private int weight;

        private string type;

        public int Weight
        {
            get => weight;
            set => weight = value;
        }

        public string Type
        {
            get => type;
            set => type = value;
        }

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
    }
}
