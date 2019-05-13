namespace _06_BirthdayCelebrations
{
    using _06_BirthdayCelebrations.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Citizen : IIdentificatable, IBirthable
    {//“<name> <age> <id>
        private string id;
        private string name;
        private string birthdata;
        private int age;

        public Citizen(string name, int age, string id, string birthdate)
        {//Citizen <name> <age> <id> <birthdate>
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
        }

        public string Id
        {
            get => this.id;
            set
            {
                this.id = value;
            }
        }

        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
            }
        }
        public int Age
        {
            get => this.age;
            set
            {
                this.age = value;
            }
        }

        public string Birthdate
        {
            get => this.birthdata;
            set
            {
                this.birthdata = value;
            }

        }
    }
}
