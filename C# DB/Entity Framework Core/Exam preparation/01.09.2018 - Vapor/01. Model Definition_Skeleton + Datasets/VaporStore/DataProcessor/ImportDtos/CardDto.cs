using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.ImportDtos
{
    public class CardDto
    {
        //"Number": "4902 6975 5076 5316",
        //    "CVC": "091",
        //    "Type": "Debit"

        [Required]
        [RegularExpression("^[0-9]{4}\\s+[0-9]{4}\\s+[0-9]{4}\\s+[0-9]{4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression("^[0-9]{3}$")]
        public string Cvc { get; set; }

        [Required]
        public string Type { get; set; }
    }
}