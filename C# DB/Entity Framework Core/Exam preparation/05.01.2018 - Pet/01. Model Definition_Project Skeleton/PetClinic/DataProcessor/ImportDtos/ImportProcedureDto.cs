using PetClinic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.ImportDtos
{
    [XmlType("Procedure")]
    public class ImportProcedureDto
    {
        //     <Vet>Niels Bohr</Vet>
        //     <Animal>acattee321</Animal>
        //<DateTime>14-01-2016</DateTime>
        [XmlElement("Vet")]
        public string Vet { get; set; }

        [XmlElement("Animal")]
        public string Animal { get; set; }

        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public AnimalAidDto[] AnimalAids{ get; set; }
    }

    [XmlType("AnimalAid")]
    public class AnimalAidDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }
    }
}
