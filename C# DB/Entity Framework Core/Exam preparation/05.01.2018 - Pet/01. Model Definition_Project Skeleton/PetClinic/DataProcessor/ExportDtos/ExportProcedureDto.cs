using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.ExportDtos
{
    [XmlType("Procedure")]
    public class ExportProcedureDto
    {
        //<Procedure>
        //<Passport>acattee321</Passport>
        //<OwnerNumber>0887446123</OwnerNumber>
        //<DateTime>14-01-2016</DateTime>
        [XmlElement("Passport")]
        public string Passport { get; set; }

        [XmlElement("OwnerNumber")]
        public string OwnerNumber { get; set; }

        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public AnimalAidDto[] AnimalAids { get; set; }

        [XmlElement("TotalPrice")]
        public string TotalPrice { get; set; }
        //<AnimalAids>
        //  <AnimalAid>
        //    <Name>Internal Deworming</Name>
        //    <Price>8.00</Price>
        //  </AnimalAid>
        //  <AnimalAid>

    }

    [XmlType("AnimalAid")]
    public class AnimalAidDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Price")]
        public string Price { get; set; }
    }
}
