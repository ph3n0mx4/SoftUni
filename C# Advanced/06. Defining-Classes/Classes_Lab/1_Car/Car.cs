using System;

namespace CarManufacturer
{
    public class Car
    {
        private string make;

        private string model;

        private int year;

        public string Make
        {
            get
            {
                return this.make;
            }

            set
            {
                if(value.Length<2)
                {
                    throw new ArgumentException("Make must be more than 1 symbol");
                }

                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if(value.Length<2)
                {
                    throw new ArgumentException("Model must be more than 1 symbol");
                }

                this.model = value;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }

            set
            {
                var dateNow = int.Parse(DateTime.Today.Year.ToString());
                if(value<1950 || value>=dateNow)
                {
                    throw new ArgumentException($"The year must be from 1950 to {dateNow}");
                }

                this.year = value;
            }
        }
    }
}
