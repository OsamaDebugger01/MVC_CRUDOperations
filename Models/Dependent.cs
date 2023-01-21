using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CRUDOperations.Models
{
    public class Dependent
    {
        [Key]
        [StringLength(20)]
        public string name { get; set; }
        [StringLength(6)]
        public string Sex { get; set; }
        [StringLength(10)]
        public string Relationship { get; set; }

        [ForeignKey("Emp_depndent")]
        public int? Emp_ssn { get; set; }
        //navigation property
        public  Employee Emp_depndent { get; set; } 
    }
}
