using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CRUDOperations.Models
{
    public class Work_For
    {
        [Key,Column(Order =1)] 
        public int Emp_ssn { get; set; }
        [Key, Column(Order = 2)]
        public int Proj_number { get; set; }

        public Employee employee { get; set; }
        public Project project { get; set;}
    }
}
