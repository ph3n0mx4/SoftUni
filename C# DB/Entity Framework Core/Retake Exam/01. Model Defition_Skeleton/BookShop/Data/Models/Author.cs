using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Data.Models
{
    public class Author
    {
        //•	Id - integer, Primary Key
        //•	FirstName - text with length[3, 30]. (required)
        //•	LastName - text with length[3, 30]. (required)
        //•	Email - text(required). Validate it! There is attribute for this job.
        //•	Phone - text.Consists only of three groups(separated by '-'), the first two consist of three digits and the last one - of 4 digits. (required)
        //text.Consists only of three groups(separated by '-'), the first two consist of three digits and the last one - of 4 digits. (required) 123-123-1234
        //•	AuthorsBooks - collection of type AuthorBook
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3), MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]  //(ErrorMessage = "Invalid Email Address")
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        public string Phone { get; set; }

        public ICollection<AuthorBook> AuthorsBooks { get; set; } = new HashSet<AuthorBook>();
    }
}
