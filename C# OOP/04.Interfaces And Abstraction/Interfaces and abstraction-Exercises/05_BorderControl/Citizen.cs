namespace _05_BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Citizen : Identificatable
    {//“<name> <age> <id>
        private string name;
        private int age;

        public Citizen(string id,string name, int age) 
            : base(id)
        {
            this.Name = name;
            this.Age = age;
        }

        string Name
        {
            get=>this.name;
            set
            {
                this.name = value;
            }
        }
        int Age
        {
            get => this.age;
            set
            {
                this.age = value;
            }
        }
    }
}
