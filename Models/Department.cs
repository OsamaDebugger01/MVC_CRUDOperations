using System.ComponentModel.DataAnnotations;

namespace MVC_CRUDOperations.Models
{
    public class Department
    {
        [Key]
        public int Number { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Location { get; set; }
        //navigation property
        public List<Project> dept_projects{ get;set; }
        public  List<DepartmentLocations> department_locations { get; set;}
    }
}
