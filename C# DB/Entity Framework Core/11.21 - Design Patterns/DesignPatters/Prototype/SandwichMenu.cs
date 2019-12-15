using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> _sandwich = 
            new Dictionary<string, SandwichPrototype>();

        public SandwichPrototype this[string name]
        {
            get { return _sandwich[name]; }
            set { _sandwich.Add(name, value); }
        }
    }
}
