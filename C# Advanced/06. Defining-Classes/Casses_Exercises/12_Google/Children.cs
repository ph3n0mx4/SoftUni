namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Child
    {
        public string ChildName { get; set; }

        public string Birthday { get; set; }

        public Child(string childName, string birthday)
        {
            ChildName = childName;
            Birthday = birthday;
        }
    }
}
