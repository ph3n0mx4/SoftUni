namespace _03_Ferrari
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Ferrari : ICar
    {
        private string driversName;
        private string model;

        public Ferrari(string driversName)
        {
            this.DriversName = driversName;
            this.Model = "488-Spider";
        }

        public string DriversName
        {
            get => this.driversName;
            set
            {
                this.driversName = value;
            }
        }

        public string Model
        {
            get => this.model;
            set
            {
                this.model = value;
            }
        }

        public string Breaks()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Breaks()}/{this.Gas()}/{this.DriversName}"; 
        }
    }
}
