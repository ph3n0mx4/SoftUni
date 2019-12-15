namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class GetUsersWithProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public SoldProductsCountDto SoldProducts { get; set; }

        //[XmlArray("SoldProducts")]
        //public ExportProductInRangeDto[] SoldProducts { get; set; }
    }
}
