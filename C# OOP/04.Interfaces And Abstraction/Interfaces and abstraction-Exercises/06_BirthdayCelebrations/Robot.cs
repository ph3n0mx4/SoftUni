namespace _06_BirthdayCelebrations
{
    using _06_BirthdayCelebrations.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Robot : IIdentificatable
    {//“<model> <id>
        private string model;
        private string id;

        public Robot(string model, string id) 
        {
            this.Id = id;
            this.Model = model;
        }

        public string Model
        {
            get=>this.model;
            set
            {
                this.model = value;
            }
        }

        public string Id
        {
            get => this.id;
            set
            {
                this.id = value;
            }
        }
    }
}
