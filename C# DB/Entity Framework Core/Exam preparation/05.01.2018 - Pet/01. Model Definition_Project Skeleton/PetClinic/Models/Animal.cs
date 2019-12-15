using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models
{
    public class Animal
    {
        //-	Id – integer, Primary Key
        //-	Name – text with min length 3 and max length 20 (required)
        //-	Type – text with min length 3 and max length 20 (required)
        //-	Age – integer, cannot be negative or 0 (required)
        //-	PassportSerialNumber ¬– string, foreign key
        //-	Passport – the passport of the animal(required)
        //-	Procedures – the procedures, performed on the animal
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Type { get; set; }

        [Required]
        [Range(typeof(int), "1", "2147483647")]
        public int Age { get; set; }

        public string PassportSerialNumber { get; set; }

        [Required]
        public Passport Passport { get; set; }

        public ICollection<Procedure> Procedures { get; set; } = new HashSet<Procedure>();
    }
}
