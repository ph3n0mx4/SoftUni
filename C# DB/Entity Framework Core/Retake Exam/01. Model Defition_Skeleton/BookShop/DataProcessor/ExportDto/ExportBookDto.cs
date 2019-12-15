using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ExportDto
{
    [XmlType("Book")]
    public class ExportBookDto
    {
        //<Book Pages = "4881" >
        //  < Name > Sierra Marsh Fern</Name>
        //  <Date>03/18/2016</Date>
        //</Book>
        [XmlAttribute("Pages")]
        public string Pages { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }

        //[XmlElement("genre")]
        //public string Genre { get; set; }

    }
}
