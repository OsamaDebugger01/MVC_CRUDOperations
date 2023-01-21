using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CRUDOperations.Models
{
    public class Employee
    {
        [Key]
        public int Ssn { get; set; }
        [StringLength(20)]
        public string Fname { get; set; }
        [StringLength(20)]
        public string Mname { get; set; }
        [StringLength(20)]
        public string Lname { get; set; }
        public DateTime Bdate { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(6)]
        public string Sex { get; set; }

        [Column("Salary",TypeName ="money")]
        public double Salary { get; set; }
        [ForeignKey("Super")]
        public int? SuperID { get; set; }
        public Employee Super { get; set; }
        public List<Employee> employees { get; set; }

        //navigation property
        public virtual List<Dependent> dependents { get; set; }
        public virtual List<Work_For> EmployeeProject { get; set; }
    }
}
