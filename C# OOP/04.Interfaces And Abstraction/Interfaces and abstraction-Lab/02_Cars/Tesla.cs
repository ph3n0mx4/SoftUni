using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        private string model;
        private string color;
        private int battery;

        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }

        public string Model
        {
            get => this.model;
            set
            {
                this.model = value;
            }
        }

        public string Color
        {
            get => this.color;
            set
            {
                this.color = value;
            }
        }

        public int Battery
        {
            get => this.battery;
            set
            {
                this.battery = value;
            }
        }

        public string Start()
        {
            return$"Engine start";
        }

        public string Stop()
        {
            return $"Breaaak!";
        }

        public override string ToString()
        {
            return $"{this.Color} {this.Model} with {this.Battery} Batteries{Environment.NewLine}{this.Start()}{Environment.NewLine}{this.Stop()}{Environment.NewLine}";
        }
    }
}
