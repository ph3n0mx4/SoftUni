using System;
using System.Collections.Generic;
using System.Text;

namespace SoftJail.Data.Models
{
    public class Department
    {
        //•	Id – integer, Primary Key
        //•	Name – text with min length 3 and max length 25 (required)
        //•	Cells - collection of type Cell
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Cell> Cells { get; set; } = new HashSet<Cell>();
    }
}
