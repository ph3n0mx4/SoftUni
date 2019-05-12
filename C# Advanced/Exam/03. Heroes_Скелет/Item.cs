using System;

namespace Heroes
{
    public class Item
    {
        //Strength: int
        //Ability: int
        //Intelligence: int
        public int Strength { get; set; }

        public int Ability { get; set; }

        public int Intelligence { get; set; }

        public Item(int strength, int ability, int intelligence)
        {
            this.Strength = strength;
            this.Ability = ability;
            this.Intelligence = intelligence;
        }

        public override string ToString()
        {
            //Item:
            //  * Strength: 23
            //  * Ability: 35
            //  * Intelligence: 48

            string output = "Item:";
            output = string.Concat(output, Environment.NewLine);

            output = string.Concat(output, $"  * Strength: {this.Strength}");
            output = string.Concat(output, Environment.NewLine);

            output = string.Concat(output, $"  * Ability: {this.Ability}");
            output = string.Concat(output, Environment.NewLine);

            output = string.Concat(output, $"  * Intelligence: {this.Intelligence}");
            output = string.Concat(output, Environment.NewLine);

            return output;
        }

    }
}
