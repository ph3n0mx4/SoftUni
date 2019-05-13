namespace _05_BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Robot : Identificatable
    {//“<model> <id>
        private string model;

        public Robot(string id, string model) 
            : base(id)
        {
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
    }
}
