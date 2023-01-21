using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CRUDOperations.Models
{
    public class Project
    {
        [Key]
        public int Number { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Location { get; set; }

        //navigation property
        public virtual Department department { get; set; }
        public virtual List<Work_For> EmployeeProject { get; set; }
    }
}
