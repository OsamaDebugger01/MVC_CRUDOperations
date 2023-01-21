using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace MVC_CRUDOperations.Models
{
    public class MVC_CRUD_dbc:DbContext
    {
        public virtual DbSet<Employee> employees { get; set; }
        public virtual DbSet<Dependent> dependents { get; set; }
        public virtual DbSet<Project> projects { get; set; }
        public MVC_CRUD_dbc()
        {

        }
        public MVC_CRUD_dbc(DbContextOptions options):base(options) {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {          
            optionsBuilder.UseSqlServer("Server=.;Database=MVC_CRUD;Trusted_Connection=True;TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasKey(o => new { o.Name, o.Number });
            modelBuilder.Entity<Work_For>().HasKey(wf => new { wf.Proj_number, wf.Emp_ssn });
            modelBuilder.Entity<Employee>().HasOne(emp => emp.Super).WithMany(emp => emp.employees)
            .HasForeignKey(emp => emp.SuperID)
            .OnDelete(DeleteBehavior.NoAction);
                base.OnModelCreating(modelBuilder);
        }
    }
}
