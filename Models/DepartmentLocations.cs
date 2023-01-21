using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CRUDOperations.Models
{
    public class DepartmentLocations
    {
        [Key]
        [ForeignKey("department")]
        public int? Dept_Number { get; set; }
        public string Location { get; set; }
        public virtual  Department department { get; set; }
    }
}
