using LoggerEx.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerEx.Layouts
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            string typeAsToLower = type.ToLower();

            switch (typeAsToLower)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("invalid type layout");
            }
        }
    }
}
