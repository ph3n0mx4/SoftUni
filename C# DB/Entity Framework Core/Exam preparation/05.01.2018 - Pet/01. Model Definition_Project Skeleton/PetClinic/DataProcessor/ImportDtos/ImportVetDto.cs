using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.ImportDtos
{
    [XmlType("Vet")]
    public class ImportVetDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(3), MaxLength(40)]
        public string Name { get; set; }

        [XmlElement("Profession")]
        [Required]
        [MinLength(3), MaxLength(50)]
        public string Profession { get; set; }

        [XmlElement("Age")]
        [Required]
        [Range(typeof(int), "22", "65")]
        public int Age { get; set; }

        [XmlElement("PhoneNumber")]
        [Required]
        [RegularExpression(@"^(\+359|0)[0-9]{9}$")]
        public string PhoneNumber { get; set; }//uniqe
    }
}
