namespace ProductShop.Dtos.Export
{
    using ProductShop.Models;
    using System.Xml.Serialization;

    [XmlType("Product")]
    public class ExportProductInRangeDto
    {
        public ExportProductInRangeDto()
        {

        }
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyer")]
        public string Buyer { get; set; }
    }
}
