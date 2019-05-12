namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Parent
    {
        public string ParentName { get; set; }

        public string ParentBirthday { get; set; }

        public Parent(string parentName, string parentBithday)
        {
            ParentName = parentName;
            ParentBirthday = parentBithday;
        }
    }
}
