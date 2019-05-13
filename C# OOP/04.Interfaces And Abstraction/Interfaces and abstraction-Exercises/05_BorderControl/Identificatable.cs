namespace _05_BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Identificatable 
    {
        private string id;
        
        public Identificatable(string id)
        {
            this.Id = id;
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
